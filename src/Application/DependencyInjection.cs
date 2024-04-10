using Application.Authentication;
using Application.UseCases.Admin;
using Application.UseCases.Championships;
using Application.UseCases.Club;
using Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        //services.AddScoped<IAuthenticationUser, AuthenticationUser>();
        services.AddScoped<IAuthenticationAdmin, AuthenticationAdmin>();

        services.AddScoped<ICreateAdminUseCase, CreateAdminUseCase>();

        //services.AddScoped<CreateUserUseCase>();
        //services.AddScoped<ReadUserUseCase>();
        //services.AddScoped<UpdateUserUseCase>();
        //services.AddScoped<DeleteUserUseCase>();


        services.AddScoped<ICreateChampionshipUseCase, CreateChampionshipUseCase>();

        services.AddScoped<ICreateClubUseCase, CreateClubUseCase>();

        //services.AddScoped<IClubChampionshipService, ClubChampionshipUseCase>();

        //services.AddScoped<CreatePlayerUseCase>();

        //services.AddScoped<CreateTeamUseCase>();

        //services.AddScoped<CreateCompetitionUseCase>();
        //services.AddScoped<ReadCompetitionUseCase>();

        // services.AddAutoMapper(typeof(UserProfile));

        return services;
    }
}
