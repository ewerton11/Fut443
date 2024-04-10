using Application.DTOs.Championship.CreateChampionship;
using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases.Championships;

public class CreateChampionshipUseCase : ICreateChampionshipUseCase
{
    private readonly IChampionshipRepository _championshipRepository;
    private readonly IAdminRepository _adminRepository;

    public CreateChampionshipUseCase(IChampionshipRepository championshipRepository, IAdminRepository adminRepository)
    {
        _championshipRepository = championshipRepository;
        _adminRepository = adminRepository;
    }

    public async Task CreateChampionshipAsync(CreateChampionshipDTO championshipDto, Guid adminId)
    {
        var admin = await _adminRepository.GetAdminAsync(adminId);

        var championship = ChampionshipEntity.Create(championshipDto.Name, championshipDto.TotalRounds, championshipDto.Season,
        championshipDto.Status, championshipDto.StartDate, championshipDto.EndDate, admin.Level);

        await _championshipRepository.AddChampionshipAsync(championship);
    }
}
