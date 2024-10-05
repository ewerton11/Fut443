using Domain.Enums;

namespace Application.DTOs.Championship.CreateChampionship;

public class CreateChampionshipDTO
{
    public string Name { get; set; } = null!;
    public int TotalRounds { get; set; }
    public int Season { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
