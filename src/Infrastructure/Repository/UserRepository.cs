﻿using Application.DTOs.ReadDTOs;
using Domain.Entities;
using Domain.Repository;
using Domain.ValueObject;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dbContext;

    public UserRepository(DataContext context)
    {
        _dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<bool> UserNameExistsAsync(UserName userName)
    {
        return await _dbContext.Users.AnyAsync(u => u.UserName.Equals(userName));
    }

    public async Task<bool> EmailExistsAsync(Email email)
    {
        return await _dbContext.Users.AnyAsync(u => u.Email.Equals(email));
    }

    public async Task<UserEntity?> GetUserByEmailAsync(Email email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));

        return user;
    }

    public async Task<object?> GetUserByIdAndTeam(Guid id)
    {
        var user = await _dbContext.Users
        .Include(u => u.Team)
        .Where(u => u.Team != null && u.Team.UserId == id)
        .Select(u => new ReadUserProfileDto
        {
            Id = u.Id,
            Name = u.Name,
            UserName = u.UserName.Value,
            Team = u.Team == null ? null : new ReadTeamUserDto
            {
                Id = u.Team.Id,
                Name = u.Team.Name.Value
            }
        })
        .FirstOrDefaultAsync();

        return user;
    }
}