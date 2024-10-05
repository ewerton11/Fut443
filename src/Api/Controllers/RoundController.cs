/*
using Application.DTOs.Round;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/round")]
public class RoundController : ControllerBase
{
    private readonly ICreateRoundUseCase _createRoundUseCase;

    public RoundController(ICreateRoundUseCase createRoundUseCase)
    {
        _createRoundUseCase = createRoundUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateRoundDTO round)
    {
        await _createRoundUseCase.CriarRodada(round);

        return Ok(new { message = "Rodada criada com sucesso!"});
    }
}
*/