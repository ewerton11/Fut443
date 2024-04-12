namespace Application.DTOs.Player.CreatePlayer;

public class CreatePlayerDTO 
{
    public string Name { get; set; } = null!;
    public string Position { get; set; } = null!;
    public Guid? ClubId { get; set; }
}
