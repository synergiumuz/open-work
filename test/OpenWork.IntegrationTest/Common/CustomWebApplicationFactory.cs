using System.Data.Common;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Npgsql;

using OpenWork.DataAccess.DbContexts;

namespace OpenWork.IntegrationTest.Customs;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureServices(services =>
		{
			var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
			services.Remove(dbContextDescriptor);
			var dbConnectionDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbConnection));
			services.Remove(dbConnectionDescriptor);
			services.AddSingleton<DbConnection>(container =>
			{
				var connection = new NpgsqlConnection("host=localhost;port=5432;user id=postgres;database=open-work-local-db;password=5482");
				connection.Open();
				return connection;
			});
			services.AddDbContext<AppDbContext>((cont, opt) =>
			{
				var connection = cont.GetRequiredService<DbConnection>();
				opt.UseNpgsql(connection);
			});
		});
		builder.UseEnvironment("Development");
	}
}
