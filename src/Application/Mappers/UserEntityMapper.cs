/*
using Application.DTOs.ReadDTOs;
using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;

namespace Application.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ReadUserProfileDto, UserEntity>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
        .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team));

        CreateMap<ReadTeamUserDto, Team>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
*/

