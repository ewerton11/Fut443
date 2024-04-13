using Application.DTOs.User.CreateUser;

namespace Application.UseCases.Interfaces;

public interface ICreateUserUseCase
{
    Task CreateUserAsync(CreateUserDTO userDto);
}
