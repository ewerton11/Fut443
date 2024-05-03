using Application.DTOs.Player.ReadPlayer;
using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;
using Domain.Repository;
using Domain.Services.Interfaces;

namespace Application.UseCases.TeamUseCase.CreateTeam;

public class CriarTimeTemporarioUseCase //implementar interface
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IChampionshipService _championshipService;
    private readonly IMapper _mapper;

    public CriarTimeTemporarioUseCase(IPlayerRepository playerRepository, IChampionshipService championshipService,
        IMapper mapper)
    {
        _playerRepository = playerRepository;
        _championshipService = championshipService;
        _mapper = mapper;
    }

    public async Task<List<ReadPlayerDTO>> CriarTimeTemporario(Guid championshipId, List<Guid> playerIds)
    {
        var team = Team.Create(null, null, championshipId);
        // Validar campeonato

        foreach (var playerId in playerIds)
        {
            PlayerEntity player = await _playerRepository.GetPlayerByIdAsync(playerId);

            bool isInChampionship = await _championshipService.IsPlayerInChampionship(player.Id, championshipId);

            if (isInChampionship)
            {
                team.AddPlayer(player);
            }
            else
            {
                throw new ApplicationException($"O jogador {player.Name} não pertence a esse campeonato.");
            }
        }

        List<PlayerEntity> playersInTeam = team.GetPlayers();

        return _mapper.Map<List<ReadPlayerDTO>>(playersInTeam);
    }
}
