﻿using Application.Authentication;
using Domain.Repository;
using Infrastructure.Authentication;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("LowAdmin", policy =>
        policy.RequireRole("LowAdmin", "MediumAdmin", "HighAdmin", "RootAdmin"));

            options.AddPolicy("MediumAdmin", policy =>
                policy.RequireRole("MediumAdmin", "HighAdmin", "RootAdmin"));

            options.AddPolicy("HighAdmin", policy =>
                policy.RequireRole("HighAdmin", "RootAdmin"));

            options.AddPolicy("RootAdmin", policy =>
                policy.RequireRole("RootAdmin"));
        });

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
        services.AddScoped<IClubRepository, ClubRepository>();
        services.AddScoped<IClubChampionshipRepository, ClubChampionshipRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<ICompetitionRepository, CompetitionRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IRoundRepository, RoundRepository>();

        return services;
    }
}