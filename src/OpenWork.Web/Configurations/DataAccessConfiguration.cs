﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OpenWork.DataAccess.DbContexts;
using OpenWork.DataAccess.Interfaces;
using OpenWork.DataAccess.Repositories;

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
		builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}
