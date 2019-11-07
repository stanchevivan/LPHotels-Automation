using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security
{
    internal class JwtGenerator 
    {
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtGenerator(JwtConfiguration jwtConfiguration)
        {
            _signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfiguration.Secret)),
                SecurityAlgorithms.HmacSha256Signature);

            _tokenHandler = new JwtSecurityTokenHandler();
        }


        public string Generate(IDictionary<string, object> claims)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = _signingCredentials,
                Subject = new ClaimsIdentity(claims.Select(x => new Claim(x.Key, x.Value.ToString())))
            };


            return _tokenHandler.CreateEncodedJwt(tokenDescriptor);
        }
    }
}
