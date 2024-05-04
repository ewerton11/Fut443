using Application.DTOs.Player.ReadPlayer;
using Application.UseCases.Interfaces;
using AutoMapper;
using Domain.Enums;
using Domain.Repository;

namespace Application.UseCases.Championships.ReadChampionship;

public class PlayersChampionshipUseCase : IPlayersChampionshipUseCase
{
    private readonly IChampionshipRepository _championshipRepository;
    private readonly IMapper _mapper;

    public PlayersChampionshipUseCase(IChampionshipRepository championshipRepository, IMapper mapper)
    {
        _championshipRepository = championshipRepository;
        _mapper = mapper;
    }

    public async Task<List<ReadPlayerDTO>> GetPlayersByChampionshipAsync(Guid championshipId, string? position)
    {
        PlayerPosition? positionEnum = null;
        if (!string.IsNullOrEmpty(position) && Enum.TryParse(position, true, out PlayerPosition parsedPosition))
        {
            positionEnum = parsedPosition;
        }

        var playerEntity = await _championshipRepository.GetAllPlayersByChampionshipAsync(championshipId, positionEnum);

        return _mapper.Map<List<ReadPlayerDTO>>(playerEntity);
    }
}
