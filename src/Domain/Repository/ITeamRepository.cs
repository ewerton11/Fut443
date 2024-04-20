using Domain.Aggregates;

namespace Domain.Repository;

public interface ITeamRepository
{
    Task CreateTeamAsync(Team team);
   // Task<Team> GetTeamByIdAsync(Guid teamId);
    //Task<Team> GetTeamByNameAsync(string teamName);
    //Task AddPlayerToTeamAsync(PlayerEntity player);
}
