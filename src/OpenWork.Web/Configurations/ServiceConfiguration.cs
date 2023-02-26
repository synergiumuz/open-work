using Microsoft.Extensions.DependencyInjection;

using OpenWork.DataAccess.Interfaces;
using OpenWork.DataAccess.Repositories;
using OpenWork.Services.Interfaces.Security;
using OpenWork.Services.Services.Security;

namespace OpenWork.Web.Configurations;

public static class ServiceConfiguration
{
	public static void AddService(this IServiceCollection services)
	{
		_ = services.AddHttpContextAccessor();
		_ = services.AddScoped<IUnitOfWork, UnitOfWork>();
		_ = services.AddScoped<IHasher, Hasher>();
		_ = services.AddScoped<IAuthManager, AuthManager>();
	}
}
