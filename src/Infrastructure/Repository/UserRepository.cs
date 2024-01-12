using AutoMapper;
using Domain.Interface.Repository;
using Infrastructure.DTOs;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IBaseRepository<BaseUserEntityDto> _baseRepository;
    private readonly IMapper _mapper;

    public UserRepository(IBaseRepository<BaseUserEntityDto> baseRepository, IMapper mapper)
    {
        _baseRepository = baseRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(BaseUserEntityDto userDto)
    {
        BaseUserEntityDto baseUserEntityDto = _mapper.Map<BaseUserEntityDto>(userDto);

        await _baseRepository.CreateAsync(baseUserEntityDto);
    }
}

