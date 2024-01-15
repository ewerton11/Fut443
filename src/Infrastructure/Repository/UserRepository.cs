using AutoMapper;
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.ValueObject;
using Infrastructure.DTOs;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IBaseRepository<User> _baseRepository;
    private readonly IMapper _mapper;

    public UserRepository(IBaseRepository<User> baseRepository, IMapper mapper)
    {
        _baseRepository = baseRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(UserEntityDto userDto)
    {
        var userResult = new User(
            userDto.UserName,
            userDto.Email,
            userDto.Password);

        var userEntity = _mapper.Map<User>(userResult);

        await _baseRepository.CreateAsync(userEntity);
    }
}

