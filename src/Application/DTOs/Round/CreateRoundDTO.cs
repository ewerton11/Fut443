namespace Application.DTOs.Round;

public class CreateRoundDTO
{
    public Guid ChampionshipId { get; set; }
    public int Number { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
