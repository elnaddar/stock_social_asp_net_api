using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY")!));
        public string CreateToken(User user)
        {
            List<Claim> claims = [
                new(JwtRegisteredClaimNames.Email, user.Email!),
                new(JwtRegisteredClaimNames.GivenName, user.UserName!)
            ];

            SigningCredentials creds = new(_key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!,
                Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}