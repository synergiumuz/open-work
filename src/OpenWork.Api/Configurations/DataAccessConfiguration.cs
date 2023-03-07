using Microsoft.EntityFrameworkCore;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces;
using OpenWork.DataAccess.Repositories;

namespace OpenWork.Api.Configurations;

public static class DataAccessConfiguration
{
	public static void ConfigureDataAccess(this WebApplicationBuilder builder, bool test = false)
	{
		string config;
		if(test)
			config = builder.Configuration.GetConnectionString("Test");
		else
			config = builder.Configuration.GetConnectionString("ElephantSQL");
		_ = builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(config));
		_ = builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}