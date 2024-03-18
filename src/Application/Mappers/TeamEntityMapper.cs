/*
using Application.DTOs.ReadDTOs;
using AutoMapper;
using Domain.Aggregates;

namespace Application.Mappers;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<Team, ReadTeamUserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value));
            Se desejar mapear a lista de jogadores, pode fazer algo como abaixo
           .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players.Select(player => new ReadPlayerDto
            {
                 Mapeie as propriedades do jogador aqui
                Id = player.Id,
                Name = player.Name,
                 ... outras propriedades do jogador
            })));
    }
}
*/