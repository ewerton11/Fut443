using Application.DTOs.Player.ReadPlayer;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

    public async Task<ChampionshipEntity> GetChampionshipWithClubsByIdAsync(Guid championshipId)
    {
        var championshipsWithClubs = await _dataContext.Championship
            .Include(champ => champ.ClubChampionships)
            .ThenInclude(cc => cc.Club)
             .FirstOrDefaultAsync(champ => champ.Id == championshipId);

        return championshipsWithClubs ?? throw new Exception($"Championship with ID {championshipId} not found.");
    }

    public async Task<List<PlayerEntity>> GetAllPlayersByChampionshipAsync(Guid championshipId)
    {
        var clubIdsInChampionship = await _dataContext.ClubChampionship
               .Where(cc => cc.ChampionshipId == championshipId)
               .Select(cc => cc.ClubId)
               .ToListAsync();

        var playersInClubs = await _dataContext.Player
               .Where(p => p.ClubId != null && clubIdsInChampionship.Contains((Guid)p.ClubId))
               .Select(p => new ReadPlayerDTO
               {
                   Id = p.Id,
                   Name = p.Name,
                   Position = p.Position.ToString(),
                   Club = p.Club
               })
        .ToListAsync();

        return _mapper.Map<List<PlayerEntity>>(playersInClubs);
    }
}
