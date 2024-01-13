using Domain.Interface.Repository;
using Infrastructure.Data;
using Infrastructure.Mappers;
using Infrastructure.Repository;
using Infrastructure.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("WebApi")));

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddAutoMapper(typeof(UserProfile));

        return services;
    }
}