using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIWithIdentityAndJwt
{
    public class JwtGenerator
    {
        public static string Generate(User user, string jwtKey,string issuer)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer: issuer, audience: issuer,
                claims: claims, signingCredentials: signing, expires: DateTime.Now.AddDays(1));

            return tokenHandler.WriteToken(token);

        }
    }
}
