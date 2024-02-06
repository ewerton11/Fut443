using Application.Service;
using Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddScoped<IAuthenticationUserService, AuthenticationUserService>();
        services.AddScoped<IAuthenticationAdminService, AuthenticationAdminService>();
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<CreateAdminUseCase>();

        //services.AddAutoMapper(typeof(UserProfile));

        return services;
    }
}
