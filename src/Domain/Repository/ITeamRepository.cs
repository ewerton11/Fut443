using Domain.Aggregates;

namespace Domain.Repository;

public interface ITeamRepository
{
    Task CreateTeamAsync(Team team);
    Task AddPlayerToTeamAsync(Team team);
    Task<Team> GetTeamByIdAsync(Guid teamId);
    Task<List<Team>> GetAllByUserIdAsync(Guid userId);
    //Task<Team> GetTeamByNameAsync(string teamName);
}
