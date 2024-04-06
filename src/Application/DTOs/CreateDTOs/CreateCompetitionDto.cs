using Domain.Aggregates;

namespace Application.DTOs.CreateDTOs;

public class CreateCompetitionDto
{
    public string Title { get; set; } = string.Empty;

    public decimal Value { get; set; }

    public Championship Championship { get; set; } = null!;
}
