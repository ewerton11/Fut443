﻿namespace Application.DTOs.User.CreateUser;

public class CreateUserDTO
{
    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
