using Application.DTOs.Player.ReadPlayer;
using Domain.Aggregates;

namespace Application.UseCases.Interfaces;

public interface IGetPlayersUseCase
{
    List<ReadPlayerDTO> GetPlayerCollection(Team team);
}
