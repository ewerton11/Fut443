using Domain.Aggregates;
using Domain.Entities;
using Domain.Repository;

namespace Infrastructure.Repository;

public class TeamRepository : ITeamRepository
{
    private readonly IBaseRepository<Team> _baseRepository;
   // private readonly IBaseRepository<PlayerEntity> _baseRepository;

    public TeamRepository(IBaseRepository<Team> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task CreateTeamAsync(Team team)
    {
        await _baseRepository.CreateAsync(team);
    }

    /*
    public async Task AddPlayerToTeamAsync(PlayerEntity player)
    {
        await _baseRepository.CreateAsync(player);
    }
    */
}
