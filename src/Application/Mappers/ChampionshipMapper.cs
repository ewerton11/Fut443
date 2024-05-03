using Application.DTOs.Championship.ReadChampionship;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class ChampionshipProfile : Profile
{
    public ChampionshipProfile()
    {
        CreateMap<ChampionshipEntity, ReadAllChampionshipDTO>();
    }
}
