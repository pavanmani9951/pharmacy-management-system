using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization_Microservice.Security
{
    public class jwtAuthenticationManager:IJwtAuthenticationManager
    {
        private readonly string Key;
        public jwtAuthenticationManager(string Key)
        {
            this.Key = Key;
        }

        public string Authenticate(string Username, string password)
        {
            if (Username == "test" && password == "Pass")
            {
                var tokenHandler = new JwtSecurityTokenHandler();// install System.IdentityModel.Tokens.Jwt
                var tokenKey = Encoding.ASCII.GetBytes(Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, Username)


                    }
                    ),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)


                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;
            
            
        }
    }
}
