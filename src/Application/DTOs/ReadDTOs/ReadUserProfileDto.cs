namespace Application.DTOs.ReadDTOs;

public class ReadUserProfileDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string UserName { get; set; }

    public ReadTeamUserDto? Team { get; set; }
}
