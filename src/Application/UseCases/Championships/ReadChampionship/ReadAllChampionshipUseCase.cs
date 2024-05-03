using Application.DTOs.Championship.ReadChampionship;
using Application.UseCases.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases.Championships.ReadChampionship;

public class ReadAllChampionshipInProgressUseCase : IReadAllChampionshipInProgressUseCase
{
    private readonly IChampionshipRepository _championshipRepository;
    private readonly IMapper _mapper;

    public ReadAllChampionshipInProgressUseCase(IChampionshipRepository championshipRepository, IMapper mapper)
    {
        _championshipRepository = championshipRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadAllChampionshipDTO>> GetAllChampionshipInProgressAsync()
    {
        var listChampionship = await _championshipRepository.GetAllChampionshipInProgressAsync();

        return _mapper.Map<IEnumerable<ChampionshipEntity>, IEnumerable<ReadAllChampionshipDTO>>(listChampionship);
    }
}
