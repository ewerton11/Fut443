namespace Application.DTOs.Competition;

public class CreateCompetitionDTO
{
    public string Title { get; set; } = null!;

    public decimal Value { get; set; }

    public Guid ChampionshipId { get; set; }
}