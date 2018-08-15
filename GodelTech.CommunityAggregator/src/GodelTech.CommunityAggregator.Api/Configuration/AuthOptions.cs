using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GodelTech.CommunityAggregator.Api.Configuration
{
    public class AuthOptions
    {
        public const string Issuer = "GodelTech.CommunityAggregator.Api";
        public const string Audience = "http://localhost:53362/";
        public const string Key = "mysupersecret_secretkey!123";
        public const int Lifetime = 10;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }

        public static void AddAuthenticationService(IServiceCollection services)
        {
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
