using Infrastructure.DTOs;

namespace Infrastructure.Repository.Abstractions;

public interface IPlayerRepository
{
    Task CreateAsync(CreatePlayerEntityDto playerDto);
}
