using Microsoft.Extensions.DependencyInjection;

using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using OpenWork.DataAccess.Interfaces;
using OpenWork.DataAccess.Interfaces.Common;
using OpenWork.DataAccess.Repositories;
using OpenWork.DataAccess.Repositories.Common;
using OpenWork.Services.Common.Security;
using OpenWork.Services.Interfaces;
using OpenWork.Services.Interfaces.Security;
using OpenWork.Services.Services;
using System.Runtime.CompilerServices;

namespace OpenWork.Web.Configurations;

public static class ServiceConfiguration
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IHasher, Hasher>();
        services.AddScoped<IAuthManager, AuthManager>();
    }
}
