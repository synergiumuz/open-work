using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenWork.Domain.Entities;
using OpenWork.Domain.Enums;
using OpenWork.Services.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Common.Security
{
    public class AuthManager : IAuthManager
    {
        private readonly IConfiguration _config;
        public AuthManager(IConfiguration config)
        {
            _config = config.GetSection("Jwt");
        }
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.Role, "user")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public string GenerateToken(Worker worker)
        {
            var claims = new[]
            {
                new Claim("Id", worker.Id.ToString()),
                new Claim("Email", worker.Email),
                new Claim(ClaimTypes.Role, "worker")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
