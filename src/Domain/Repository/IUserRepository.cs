﻿using Domain.ValueObject;

namespace Domain.Repository;

public interface IUserRepository
{
    Task<bool> UserNameExistsAsync(UserName userName);
    Task<bool> EmailExistsAsync(Email email);
    Task<UserEntity?> GetUserByEmailAsync(Email email);
    Task<object?> GetUserByIdAndTeam(Guid id);
}
