/*
using Application.DTOs.Round;
using Application.UseCases.Interfaces;
using Domain.Aggregates;
using Domain.Repository;

namespace Application.UseCases.RoundUseCase;

public class CreateRoundUseCase : ICreateRoundUseCase
{
    private readonly IRoundRepository _roundRepository;

    public CreateRoundUseCase(IRoundRepository roundRepository)
    {
        _roundRepository = roundRepository;
    }

    public async Task CriarRodada(CreateRoundDTO roundDto)
    {

        Round round = Round.Create(roundDto.Number, roundDto.StartDate, roundDto.EndDate, roundDto.ChampionshipId);

        await _roundRepository.CriarRodada(round);
    }
}
*/