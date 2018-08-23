using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GodelTech.CommunityAggregator.Api.Configuration
{
    public class AuthOptions
    {
        public static string Issuer;
        public static string Audience;
        public static string Key;
        public static int LifeTime;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }

        public static void AddAuthenticationService(IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection("TokenConfig");
            Issuer = section.GetSection("Issuer").Value;
            Audience = section.GetSection("Audience").Value;
            Key = section.GetSection("Key").Value;
            if (!int.TryParse(section.GetSection("Lifetime").Value, out LifeTime))
            {
                throw new Exception("Token life time parameter is wrong");
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Issuer,

                        ValidateAudience = true,
                        ValidAudience = Audience,
                        ValidateLifetime = true,
                        
                        IssuerSigningKey = GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
        }
    }
}
