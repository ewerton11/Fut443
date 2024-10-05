/*
using Application.DTOs.ClubChampionship.ReadClubChampionship;
using Application.UseCases.Interfaces;
using Domain.Repository;

namespace Application.UseCases.Championships.ReadChampionship;

public class ReadChampionshipWithClubsUseCase : IReadChampionshipWithClubsUseCase
{
    private readonly IChampionshipRepository _championshipRepository;

    public ReadChampionshipWithClubsUseCase(IChampionshipRepository championshipRepository)
    {
        _championshipRepository = championshipRepository;
    }

    public async Task<ChampionshipDTO> GetChampionshipWithClubsByIdAsync(Guid championshipId)
    {
        var championship = await _championshipRepository.GetChampionshipWithClubsByIdAsync(championshipId);

        var championshipDTO = ChampionshipMapper.MapToDTO(championship);

        return championshipDTO;
    }
}
*/
