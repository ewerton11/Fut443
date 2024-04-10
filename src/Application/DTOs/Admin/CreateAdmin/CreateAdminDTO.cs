using Domain.Enums;

namespace Application.DTOs.Admin;

public class CreateAdminDTO
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public AdminLevel level { get; set; }
}
