using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OpenWork.Api.Configurations
{
	public static class JwtConfiguration
	{
		public static void ConfigureAuth(this WebApplicationBuilder builder)
		{
			Microsoft.Extensions.Configuration.IConfigurationSection config = builder.Configuration.GetSection("Jwt");
			_ = builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidIssuer = config["Issuer"],
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["SecretKey"]))
					};
				});

		}
	}
}
