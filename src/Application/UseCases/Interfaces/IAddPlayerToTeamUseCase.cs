using Domain.Entities;

namespace Application.UseCases.Interfaces;

public interface IAddPlayerToTeamUseCase
{
    Task AddPlayerToTeamAsync(Guid userId, Guid championshipId, Guid teamId, Guid playerId);
}
