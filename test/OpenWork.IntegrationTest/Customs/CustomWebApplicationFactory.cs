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
				var connection = new NpgsqlConnection("host=floppy.db.elephantsql.com;port=5432;database=cjupxcwj;user id=cjupxcwj;password=Bnjs8fil7y2ivkjjWepVvOhrve05RHCQ");
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
