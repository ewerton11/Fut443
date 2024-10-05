using Application.DTOs.Player.ReadPlayer;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Infrastructure.Repository;

public class ChampionshipRepository : IChampionshipRepository
{
    private readonly IBaseRepository<ChampionshipEntity> _baseRepository;
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public ChampionshipRepository(IBaseRepository<ChampionshipEntity> baseRepository, DataContext dataContext,
        IMapper mapper)
    {
        _baseRepository = baseRepository;
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task AddChampionshipAsync(ChampionshipEntity championship)
    {
        await _baseRepository.CreateAsync(championship);
    }

    public async Task<ChampionshipEntity> GetChampionshipByIdAsync(Guid championshipId)
    {
        var championship = await _baseRepository.GetByIdAsync(championshipId);

        return championship;
    }

    public async Task<bool> TheNameOfTheChampionshipAlreadyExists(string name)
    {
        var existingChampionship = await _dataContext.Championship.FirstOrDefaultAsync(c => c.Name == name);
        return existingChampionship != null;
    }

    public async Task<IEnumerable<ChampionshipEntity>> GetAllChampionshipInProgressAsync()
    {
        var championshipsInProgress = await _dataContext.Championship
            .Where(c => c.Status == ChampionshipStatus.InProgress)
            .ToListAsync();

        return championshipsInProgress;
    }

    public async Task<ChampionshipEntity> GetChampionshipWithClubsByIdAsync(Guid championshipId)
    {
        var championshipsWithClubs = await _dataContext.Championship
            .Include(champ => champ.ClubChampionships)
            .ThenInclude(cc => cc.Club)
             .FirstOrDefaultAsync(champ => champ.Id == championshipId);

        return championshipsWithClubs ?? throw new Exception($"Championship with ID {championshipId} not found.");
    }

    public async Task<List<PlayerEntity>> GetAllPlayersByChampionshipAsync(Guid championshipId, PlayerPosition? position)
    {
        var clubIdsInChampionship = await _dataContext.ClubChampionship
               .Where(cc => cc.ChampionshipId == championshipId)
               .Select(cc => cc.ClubId)
        .ToListAsync();

        IQueryable<PlayerEntity> playersQuery = _dataContext.Player
        .Where(p => p.ClubId != null && clubIdsInChampionship.Contains((Guid)p.ClubId));

        if (position != null) 
        {
            playersQuery = playersQuery.Where(p => p.Position == position);
        }

        var playersInClubs = await playersQuery
       .Select(p => new ReadPlayerDTO
       {
           Id = p.Id,
           Name = p.Name,
           Position = p.Position.ToString(),
           SpecificPosition = p.SpecificPosition.ToString(),
           ClubName = p.ClubName
       })
       .ToListAsync();

        return _mapper.Map<List<PlayerEntity>>(playersInClubs);
    }

    public async Task UpdateCurrentPhaseAsync(ChampionshipEntity championship)
    {
        await _baseRepository.UpdateAsync(championship);
    }
}
