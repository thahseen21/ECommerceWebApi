using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CustomModel;

namespace PresentationLayer.Utils
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        private readonly DateTime expiresIn = DateTime.Now.AddDays(1);

        public JwtHelper(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        //Retrieve the key from appsetting.json .
        private SymmetricSecurityKey GetKey()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            return key;
        }

        // Cryptographic key and security algorithms that are used to generate a digital signature.
        private SigningCredentials GenerateSigningCred(SymmetricSecurityKey key)
        {
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            return creds;
        }

        // All the token related properties are generated here.
        private SecurityTokenDescriptor GenerateTokenDescriptor(List<Claim> claims, SigningCredentials signinCreds)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = this.expiresIn,
                SigningCredentials = signinCreds
            };
            return tokenDescriptor;
        }

        // The token is generated here using the above private methods.
        public string GenerateToken(GenerateTokenCustomModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.RoleName)
            };

            var key = this.GetKey();

            var signCreds = this.GenerateSigningCred(key);

            var tokenDescriptor = this.GenerateTokenDescriptor(claims, signCreds);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}