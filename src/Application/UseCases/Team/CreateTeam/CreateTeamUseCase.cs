using Application.DTOs.Team.CreateTeam;
using Application.UseCases.Interfaces;
using Domain.Aggregates;
using Domain.Repository;

namespace Application.UseCases.TeamUseCase;

public class CreateTeamUseCase : ICreateTeamUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ITeamRepository _teamRepository;

    public CreateTeamUseCase(IUserRepository userRepository, ITeamRepository teamRepository)
    {
        _userRepository = userRepository;
        _teamRepository = teamRepository;
    }

    public async Task CreateTeamAsync(CreateTeamDTO teamDto, Guid userId, Guid championshipId)
    {
        var user = await _userRepository.GetUserWithTeamByIdAsync(userId);

        var team = Team.Create(user, teamDto.Name, championshipId);

        await _teamRepository.CreateTeamAsync(team);
    }
}
