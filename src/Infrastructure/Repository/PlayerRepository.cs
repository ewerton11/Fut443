using Application.DTOs.Player.ReadPlayer;
using Domain.Entities;
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

    public async Task<List<object>> GetAllPlayersByChampionshipAsync(Guid championshipId)
    {
        //converter retorno para a entidade
        var clubIdsInChampionship = await _dataContext.ClubChampionship
               .Where(cc => cc.ChampionshipId == championshipId)
               .Select(cc => cc.ClubId)
               .ToListAsync();

        var playersInClubs = await _dataContext.Player
               .Where(p => p.ClubId != null && clubIdsInChampionship.Contains((Guid)p.ClubId))
               .Select(p => new ReadPlayerDTO
               {
                   Name = p.Name,
                   Position = p.Position,
                   Club = p.Club
               })
               .ToListAsync();

        return playersInClubs.Cast<object>().ToList();
    }

    public async Task<bool> IsPlayerInClubAsync(string name, string club)
    {
        var existingPlayer = await _dataContext.Player
            .Where(p => p.Name == name && p.Club == club)
                .FirstOrDefaultAsync();

        return existingPlayer != null;
    }
}
