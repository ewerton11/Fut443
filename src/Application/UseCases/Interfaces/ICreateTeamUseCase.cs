using Application.DTOs.Team.CreateTeam;

namespace Application.UseCases.Interfaces;

public interface ICreateTeamUseCase
{
    Task CreateTeamAsync(CreateTeamDTO teamDto, Guid userId, Guid championshipId);
}
