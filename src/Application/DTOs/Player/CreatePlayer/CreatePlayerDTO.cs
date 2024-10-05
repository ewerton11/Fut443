using Domain.Enums;

namespace Application.DTOs.Player.CreatePlayer;

public class CreatePlayerDTO 
{
    public string Name { get; set; } = null!;
    public string Position { get; set; } = null!;
    public string SpecificPosition { get; set; } = null!;
    public AvailabilityStatus Status { get; set; }
    public string? ClubName { get; set; }
    public Guid? ClubId { get; set; }
}
