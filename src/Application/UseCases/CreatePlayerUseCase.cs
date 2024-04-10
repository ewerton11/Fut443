/*
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases;

public class CreatePlayerUseCase
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IBaseRepository<PlayerEntity> _baseRepository;

    public CreatePlayerUseCase(IPlayerRepository playerRepository, IBaseRepository<PlayerEntity> baseRepository)
    {
        _playerRepository = playerRepository;
        _baseRepository = baseRepository;
    }

    public async Task CreatePlayer(string name, string position, string club)
    {
        if (await _playerRepository.IsPlayerInClubAsync(name, club))
        {
            throw new InvalidOperationException("This player already exists.");
        }

        var player = PlayerEntity.Create(name, position, club);

        await _baseRepository.CreateAsync(player);
    }
}
*/