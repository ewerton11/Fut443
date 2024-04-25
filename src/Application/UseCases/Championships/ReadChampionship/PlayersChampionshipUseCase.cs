using Application.DTOs.Player.ReadPlayer;
using Application.UseCases.Interfaces;
using AutoMapper;
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

    public async Task<List<ReadPlayerDTO>> GetPlayersByChampionshipAsync(Guid championshipId)
    {
        var playerEntity = await _championshipRepository.GetAllPlayersByChampionshipAsync(championshipId);

        return _mapper.Map<List<ReadPlayerDTO>>(playerEntity);
    }
}
