using Application.Service;
using Domain.Repository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<UserService>();

        //services.AddAutoMapper(typeof(UserProfile));

        return services;
    }
}
