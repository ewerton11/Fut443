using Application.DTOs.Club.CreateClub;
using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases.Club;

public class CreateClubUseCase : ICreateClubUseCase
{
    private readonly IClubRepository _clubRepository;
    private readonly IAdminRepository _adminRepository;

    public CreateClubUseCase(IClubRepository clubRepository, IAdminRepository adminRepository)
    {
        _clubRepository = clubRepository;
        _adminRepository = adminRepository;
    }

    public async Task CreateClubAsync(CreateClubDTO clubDto, Guid clubId)
    {
        var admin = await _adminRepository.GetAdminAsync(clubId);

        var club = ClubEntity.Create(clubDto.Name, clubDto.Country, clubDto.Trainer, admin.Level);

        await _clubRepository.AddClubAsync(club);
    }
}
