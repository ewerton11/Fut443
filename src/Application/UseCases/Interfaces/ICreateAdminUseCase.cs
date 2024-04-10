using Application.DTOs.Admin;
using Application.DTOs.Championship.CreateChampionship;

namespace Application.UseCases.Interfaces;

public interface ICreateAdminUseCase
{
    Task CreateAdminAsync(CreateAdminDTO adminDto, Guid adminId);
}
