using Application.UseCases.Interfaces;
using Domain.Aggregates;
using Domain.Entities;
using Domain.Repository;
using Domain.Services.Interfaces;

namespace Application.UseCases.TeamUseCase;

public class AddPlayerToTeamUseCase : IAddPlayerToTeamUseCase
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IChampionshipService _championshipService;
    private readonly IUserRepository _userRepository;
    private readonly ITeamRepository _teamRepository;

    public AddPlayerToTeamUseCase(IPlayerRepository playerRepository, IChampionshipService championshipService, 
        IUserRepository userRepository, ITeamRepository teamRepository)
    {
        _playerRepository = playerRepository;
        _userRepository = userRepository;
        _teamRepository = teamRepository;
        _championshipService = championshipService;
    }

    public async Task AddPlayerToTeamAsync(Guid userId, Guid championshipId, Guid teamId, Guid playerId)
    {
        PlayerEntity player = await _playerRepository.GetPlayerByIdAsync(playerId);

        bool isInChampionship = await _championshipService.IsPlayerInChampionship(player.Id, championshipId);

        if (!isInChampionship)
        {
            throw new ApplicationException("O jogador não pertence a essa campeonato.");
        }

        var user = await _userRepository.GetUserWithTeamByIdAsync(userId);

        var team = user.GetTeam(teamId)
            ?? throw new ArgumentException("Time nao encontrado.");

        team.AddPlayer(player);

        await _teamRepository.AddPlayerToTeamAsync(team);
    }
}
