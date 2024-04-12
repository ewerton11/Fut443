using Application.DTOs.ClubChampionship;

namespace Application.UseCases.Interfaces;

public interface IAddClubToChampionshipUseCase
{
    Task AddClubToChampionship(AddClubToChampionshipDTO clubToChampionshipDto);
}
