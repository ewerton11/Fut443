using Domain.Aggregates;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TeamRepository : ITeamRepository
{
    private readonly IBaseRepository<Team> _baseRepository;
    private readonly DataContext _dataContext;
    // private readonly IBaseRepository<PlayerEntity> _baseRepository;

    public TeamRepository(IBaseRepository<Team> baseRepository, DataContext dataContext)
    {
        _baseRepository = baseRepository;
        _dataContext = dataContext;
    }

    public async Task CreateTeamAsync(Team team)
    {
        await _baseRepository.CreateAsync(team);
    }

    public async Task AddPlayerToTeamAsync(Team team)
    {
        await _baseRepository.UpdateAsync(team);
    }

    public async Task<Team> GetTeamByIdAsync(Guid teamId)
    {
        var team = await _baseRepository.GetByIdAsync(teamId);

        return team;
    }

    public async Task<List<Team>> GetAllByUserIdAsync(Guid userId)
    {
        var teams = await _dataContext.Team.Where(t => t.UserId == userId).ToListAsync();

        return teams;
    }
}
