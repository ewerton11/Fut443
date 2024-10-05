using Application.DTOs.Championship.CreateChampionship;

namespace Application.UseCases.Interfaces;

public interface ICreateChampionshipUseCase
{
    Task CreateChampionshipAsync(Guid adminId, CreateChampionshipDTO championshipDto);
}
