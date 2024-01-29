/*
using Domain.Entities;
using Domain.Interface.Repository;
using Infrastructure.DTOs;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly IBaseRepository<PlayerEntity> _baseRepository;

    public PlayerRepository(IBaseRepository<PlayerEntity> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task CreateAsync(CreatePlayerEntityDto playerDto)
    {
        var player = PlayerEntity.Create(playerDto.Name, playerDto.Position);

        await _baseRepository.CreateAsync(player);
    }
}
*/