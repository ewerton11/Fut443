using Application.DTOs.Championship.CreateChampionship;
using Application.UseCases.Interfaces;
using Domain.Aggregates;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases.ChampionshipUseCase;

public class CreateChampionshipUseCase : ICreateChampionshipUseCase
{
    private readonly IAdminRepository _adminRepository;
    private readonly IChampionshipRepository _championshipRepository;

    public CreateChampionshipUseCase(IAdminRepository adminRepository, IChampionshipRepository championshipRepository)
    {
        _adminRepository = adminRepository;
        _championshipRepository = championshipRepository;
    }

    public async Task CreateChampionshipAsync(Guid adminId, CreateChampionshipDTO championshipDto)
    {
        AdminEntity admin = await _adminRepository.GetAdminAsync(adminId);

        bool existingChampionship = await _championshipRepository
            .TheNameOfTheChampionshipAlreadyExists(championshipDto.Name);

        if(existingChampionship)
        {
            throw new ArgumentException("The name of this championship is already being used");
        }

        ChampionshipEntity championship = ChampionshipEntity.Create(championshipDto.Name, championshipDto.TotalRounds,
            championshipDto.Season, championshipDto.StartDate, championshipDto.EndDate, admin.Level);

        if(championship.TotalRounds > 100)
        {
            throw new ArgumentException("Very high number of rounds");
        }

        for (int rounds = 1; rounds <= championship.TotalRounds; rounds++)
        {
            Round round = Round.Create(rounds, championship.Season, championship.Id);

            championship.AddRound(round);
        }

        await _championshipRepository.AddChampionshipAsync(championship);
    }
}
