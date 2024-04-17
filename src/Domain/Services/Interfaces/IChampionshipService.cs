namespace Domain.Services.Interfaces;

public interface IChampionshipService
{
    Task<bool> IsPlayerInChampionship(Guid playerId, Guid championshipId);
}

