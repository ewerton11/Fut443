using Application.DTOs.Club.CreateClub;

namespace Application.UseCases.Interfaces;

public interface ICreateClubUseCase
{
    Task CreateClubAsync(CreateClubDTO clubDto, Guid clubId);
}
