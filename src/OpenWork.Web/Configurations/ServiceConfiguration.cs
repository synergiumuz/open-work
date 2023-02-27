using Microsoft.Extensions.DependencyInjection;

using OpenWork.DataAccess.Interfaces;
using OpenWork.DataAccess.Repositories;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Common;
using OpenWork.Services.Interfaces.Security;
using OpenWork.Services.Services;
using OpenWork.Services.Services.Common;
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
		_ = services.AddScoped<IWorkerService, WorkerService>();
		_ = services.AddScoped<IUserService, UserService>();
		_ = services.AddScoped<IEmailService, EmailService>();
		_ = services.AddScoped<IAuthManager, AuthManager>();
		_ = services.AddScoped<IWorkerService, WorkerService>();
		_ = services.AddScoped<IIdentityService, IdentityService>();
			
	}
}
