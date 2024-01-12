using AutoMapper;
using Domain.Common;
using Infrastructure.DTOs;

namespace Infrastructure.Mappers;

public class BaseUserProfile : Profile
{
    public BaseUserProfile()
    {
        CreateMap<BaseUserEntity, BaseUserEntityDto>()
            .ReverseMap();
    }
}
