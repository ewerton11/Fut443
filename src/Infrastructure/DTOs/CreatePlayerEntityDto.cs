using Domain.Enums;

namespace Infrastructure.DTOs;

public class CreatePlayerEntityDto
{
    public string Name { get; set; }

    public string Position { get; set; }
}