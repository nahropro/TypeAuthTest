using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TypeAuthTest.Models;
using TypeAuthTest.Services.Interfaces;

namespace TypeAuthTest.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateJwtToken(User user, int expireAfterDays = 30)
        {
            string accessTrees = "[" +
                String.Join(",", user.UserInRoles
                .Where(x => !string.IsNullOrWhiteSpace(x.Role.AccessTree))
                .Select(x => x.Role.AccessTree).ToArray())
                + "]";

            var claims = new[]
            {
                new Claim("UserName", user.Username),
                new Claim("UserId",user.Id.ToString()),
                new Claim("AccessTrees", accessTrees)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerySecretKeyVerySecretKeyVerySecretKeyVerySecretKeyVerySecretKey"));

            var token = new JwtSecurityToken(
                issuer: "TypeAuth",
                audience: "TypeAuth",
                claims: claims,
                expires: DateTime.Now.AddDays(expireAfterDays),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature));

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
