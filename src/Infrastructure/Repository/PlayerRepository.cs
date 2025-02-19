﻿using Domain.Entities;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly IBaseRepository<PlayerEntity> _baseRepository;
    private readonly DataContext _dataContext;


    public PlayerRepository(IBaseRepository<PlayerEntity> baseRepository, DataContext dataContext)
    {
        _baseRepository = baseRepository;
        _dataContext = dataContext;
    }

    public async Task CreatePlayerAsync(PlayerEntity player)
    {
        await _baseRepository.CreateAsync(player);
    }

    public async Task<PlayerEntity> GetPlayerByIdAsync(Guid playerId)
    {
        var player = await _baseRepository.GetByIdAsync(playerId);

        return player;
    }
    
    public async Task<bool> IsPlayerInClubAsync(string name, string clubName)
    {
        var existingPlayer = await _dataContext.Player
            .Where(p => p.Name == name && p.ClubName == clubName)
                .FirstOrDefaultAsync();

        return existingPlayer != null;
    }
}
