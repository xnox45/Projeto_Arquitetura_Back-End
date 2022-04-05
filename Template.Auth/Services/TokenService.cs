using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Template.Auth.Models;
using Template.Domain.Entities;

namespace Template.Auth.Services
{
    public class TokenService
    {
        public static string GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            
            byte[] key = Encoding.ASCII.GetBytes(Settings.Secret);

            SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Mail),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

    }
}
