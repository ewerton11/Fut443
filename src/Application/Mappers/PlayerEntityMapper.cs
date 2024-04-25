using Application.DTOs.Player.ReadPlayer;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<PlayerEntity, ReadPlayerDTO>()
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.ToString()));
        CreateMap<ReadPlayerDTO, PlayerEntity>()
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.ToString()));
    }
}