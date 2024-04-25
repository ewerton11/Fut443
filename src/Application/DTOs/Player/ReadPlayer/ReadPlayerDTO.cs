using Domain.Enums;

namespace Application.DTOs.Player.ReadPlayer;

public class ReadPlayerDTO
{
    public string Name { get; set; } = null!;
    public PlayerPosition Position { get; set; }
    public string? Club { get; set; }
}

