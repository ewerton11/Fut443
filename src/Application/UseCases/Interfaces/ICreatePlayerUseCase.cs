using Application.DTOs.Player.CreatePlayer;

namespace Application.UseCases.Interfaces;

public interface ICreatePlayerUseCase
{
    Task CreatePlayerAsync(CreatePlayerDTO playerDto, Guid adminId);
}
