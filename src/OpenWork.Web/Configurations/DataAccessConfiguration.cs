using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;

namespace OpenWork.Web.Configurations;

public static class DataAccessConfiguration
{
	public static void ConfigureDataAccess(this WebApplicationBuilder builder)
	{
		string config = builder.Configuration.GetConnectionString("ElephantSQL");
		builder.Services.AddDbContext<AppDbContext>(opt =>
		{
			opt.UseNpgsql(config);
		});
	}
}
