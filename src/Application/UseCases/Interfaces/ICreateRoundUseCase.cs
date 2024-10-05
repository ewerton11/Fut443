using Application.DTOs.Round;

namespace Application.UseCases.Interfaces;

public interface ICreateRoundUseCase
{
    Task CriarRodada(CreateRoundDTO roundDto);
}
