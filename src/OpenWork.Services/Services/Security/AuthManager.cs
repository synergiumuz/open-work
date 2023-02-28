using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using OpenWork.Domain.Entities;
using OpenWork.Services.Interfaces.Security;

namespace OpenWork.Services.Services.Security;

public class AuthManager : IAuthManager
{
	private readonly IConfiguration _config;
	public AuthManager(IConfiguration config)
	{
		_config = config.GetSection("Jwt");
	}
	public string GenerateToken(User user)
	{
		Claim[] claims = new[]
		{
			new Claim("Id", user.Id.ToString()),
			new Claim("Email", user.Email),
			new Claim(ClaimTypes.Role, user.Admin?"Admin":"User")
		};

		SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
		SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

		JwtSecurityToken tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
			expires: DateTime.Now.AddMonths(int.Parse(_config["Lifetime"])),
			signingCredentials: credentials);
		return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
	}

	public string GenerateToken(Worker worker)
	{
		Claim[] claims = new[]
		{
			new Claim("Id", worker.Id.ToString()),
			new Claim("Email", worker.Email),
			new Claim(ClaimTypes.Role, "Worker")
		};

		SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
		SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

		JwtSecurityToken tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
			expires: DateTime.Now.AddMonths(int.Parse(_config["Lifetime"])),
			signingCredentials: credentials);
		return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
	}
}
