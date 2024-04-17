using Application.DTOs.Player.CreatePlayer;
using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases.Player;

public class CreatePlayerUseCase : ICreatePlayerUseCase
{
    private readonly IAdminRepository _adminRepository;
    private readonly IPlayerRepository _playerRepository;

    public CreatePlayerUseCase(IAdminRepository adminRepository, IPlayerRepository playerRepository)
    {
        _adminRepository = adminRepository;
        _playerRepository = playerRepository;
    }

    public async Task CreatePlayerAsync(CreatePlayerDTO playerDto, Guid adminId)
    {
        //validaçoes

        var creatorAdmin = await _adminRepository.GetAdminAsync(adminId);

        var player = PlayerEntity.Create(playerDto.Name, playerDto.Position, playerDto.Status, playerDto.ClubId, creatorAdmin.Level);

        await _playerRepository.CreatePlayerAsync(player);
    }
}
