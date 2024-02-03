﻿using Domain.Repository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
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
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("WebApi")));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Password-Fake-69696-Fut433"))
            };
        });

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<PasswordHashService>();
        //services.AddScoped<TokenService>();

        return services;
    }
}