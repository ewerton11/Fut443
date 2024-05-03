using Application.DTOs.Championship.ReadChampionship;

namespace Application.UseCases.Interfaces;

public interface IReadAllChampionshipInProgressUseCase
{
    Task<IEnumerable<ReadAllChampionshipDTO>> GetAllChampionshipInProgressAsync();
}

