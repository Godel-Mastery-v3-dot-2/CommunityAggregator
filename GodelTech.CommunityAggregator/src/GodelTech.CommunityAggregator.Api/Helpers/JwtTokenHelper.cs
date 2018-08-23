using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using GodelTech.CommunityAggregator.Api.Configuration;
using GodelTech.CommunityAggregator.Api.Models;
using Microsoft.IdentityModel.Tokens;

namespace GodelTech.CommunityAggregator.Api.Helpers
{
    public static class JwtTokenHelper
    {
        public static TokenView GetJwtToken(ClaimsIdentity identity, string userName)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                AuthOptions.Issuer,
                AuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var result = new TokenView
            {
                Login = userName,
                TokenBody = encodedJwt
            };

            return result;
        }
    }
}
