namespace Application.DTOs.Player.ReadPlayer;

public class ReadPlayerDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Position { get; set; } = null!;
    public string SpecificPosition { get; set; } = null!;
    public string? ClubName { get; set; }
}

