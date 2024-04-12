using Application.DTOs.ClubChampionship;
using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases.ClubChampionshipUseCase;

public class AddClubToChampionshipUseCase : IAddClubToChampionshipUseCase
{
    private readonly IClubChampionshipRepository _clubChampionshipRepository;
    private readonly IClubRepository _clubRepository;
    private readonly IChampionshipRepository _championshipRepository;

    public AddClubToChampionshipUseCase(IClubChampionshipRepository clubChampionshipRepository,
         IClubRepository clubRepository, IChampionshipRepository championshipRepository)
    {
        _clubChampionshipRepository = clubChampionshipRepository;
        _clubRepository = clubRepository;
        _championshipRepository = championshipRepository;
    }

    public async Task AddClubToChampionship(AddClubToChampionshipDTO clubToChampionshipDto)
    {
        var club = await _clubRepository.GetClubByIdAsync(clubToChampionshipDto.ClubId);
        var championship = await _championshipRepository.GetChampionshipByIdAsync(clubToChampionshipDto.ChampionshipId);

        var clubChampionship = ClubChampionship.Associate(club, championship);

        await _clubChampionshipRepository.AddClubToChampionshipAsync(clubChampionship);
    }
}
