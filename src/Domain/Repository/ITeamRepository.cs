using Domain.Aggregates;

namespace Domain.Repository;

public interface ITeamRepository
{
    Task<Team> GetTeamByIdAsync(Guid teamId);
    //Task<Team> GetTeamByNameAsync(string teamName);
    Task CreateTeamAsync(Team team);
    Task AddPlayerToTeamAsync(Guid teamId, PlayerEntity player);
}
