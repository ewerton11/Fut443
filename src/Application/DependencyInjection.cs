﻿using Application.Authentication;
using Application.Mappers;
using Application.UseCases;
using Application.UseCases.Admin;
using Application.UseCases.ChampionshipUseCase;
using Application.UseCases.Club;
using Application.UseCases.ClubChampionshipUseCase;
using Application.UseCases.CompetitionUseCase;
using Application.UseCases.Interfaces;
using Application.UseCases.Player;
using Application.UseCases.Schedulers;
using Application.UseCases.TeamUseCase;
using Application.UseCases.TeamUseCase.CreateTeam;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        //business
        services.AddScoped<IChampionshipService, ChampionshipService>();

        services.AddScoped<IAuthenticationAdmin, AuthenticationAdmin>();
        services.AddScoped<IAuthenticationUser, AuthenticationUser>();

        services.AddScoped<ICreateAdminUseCase, CreateAdminUseCase>();

        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();

        //services.AddScoped<ReadUserUseCase>();
        //services.AddScoped<UpdateUserUseCase>();
        //services.AddScoped<DeleteUserUseCase>();


        services.AddScoped<ICreateChampionshipUseCase, CreateChampionshipUseCase>();

        services.AddScoped<ICreateClubUseCase, CreateClubUseCase>();

        services.AddScoped<IAddClubToChampionshipUseCase, AddClubToChampionshipUseCase>();

        services.AddScoped<IPlayersChampionshipUseCase, PlayersChampionshipUseCase>();

        services.AddScoped<ICreatePlayerUseCase, CreatePlayerUseCase>();

        services.AddScoped<ICreateTeamUseCase, CreateTeamUseCase>();
        services.AddScoped<IAddPlayerToTeamUseCase, AddPlayerToTeamUseCase>();

        //services.AddScoped<CreateTeamUseCase>();

        services.AddScoped<ICreateCompetitionUseCase, CreateCompetitionUseCase>();
        services.AddScoped<IBaseUserEntityService, BaseUserEntityService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<CriarTimeTemporarioUseCase>();
        services.AddScoped<IReadAllChampionshipInProgressUseCase, ReadAllChampionshipInProgressUseCase>();
        services.AddScoped<RoundUpdateScheduler>();

        //services.AddScoped<ReadCompetitionUseCase>();

        services.AddAutoMapper(typeof(PlayerProfile));

        return services;
    }
}
