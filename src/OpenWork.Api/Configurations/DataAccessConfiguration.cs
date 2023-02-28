using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces;
using OpenWork.DataAccess.Repositories;

namespace OpenWork.Api.Configurations;

public static class DataAccessConfiguration
{
	public static void ConfigureDataAccess(this WebApplicationBuilder builder)
	{
		string config = builder.Configuration.GetConnectionString("ElephantSQL");
		_ = builder.Services.AddDbContext<AppDbContext>(opt =>
		{
			_ = opt.UseNpgsql(config);
		});
		_ = builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}
