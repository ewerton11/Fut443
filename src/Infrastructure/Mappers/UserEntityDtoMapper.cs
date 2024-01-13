using AutoMapper;
using Domain.Entities;
using Infrastructure.DTOs;

namespace Infrastructure.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    { 
        CreateMap<User, UserEntityDto>()
          .ReverseMap();
    }
}
