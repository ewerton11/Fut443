using Application.Authentication;
using Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddScoped<IAuthenticationUser, AuthenticationUser>();
        services.AddScoped<IAuthenticationAdmin, AuthenticationAdmin>();
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<CreateAdminUseCase>();
        services.AddScoped<CreatePlayerUseCase>();
        services.AddScoped<CreateTeamUseCase>();
        services.AddScoped<UpdateUserUseCase>();
        services.AddScoped<DeleteUserUseCase>();

        //services.AddAutoMapper(typeof(UserProfile));

        return services;
    }
}
