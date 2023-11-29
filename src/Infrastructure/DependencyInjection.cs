using Domain.Interface.Repository;
using Infrastructure.Repository;
using Infrastructure.Repository.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IBaseRepository, BaseRepository>();

        return services;
    }
}