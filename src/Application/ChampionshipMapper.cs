/*
using Application.DTOs.ClubChampionship.ReadClubChampionship;
using Application.DTOs.ReadDTOs;
using Domain.Aggregates;

namespace Application;

public class ChampionshipMapper
{
    public static ChampionshipDTO MapToDTO(Championship championship)
    {
        var championshipDTO = new ChampionshipDTO
        {
            Name = championship.Name,
            TotalRounds = championship.TotalRounds,
            CurrentPhase = championship.CurrentPhase,
            Season = championship.Season,
            Status = championship.Status,
            StartDate = championship.StartDate,
            EndDate = championship.EndDate,
            Clubs = championship.ClubChampionships
                .Select(cc => new ClubDTO
                {
                    Name = cc.Club.Name,
                    Country = cc.Club.Country,
                    Trainer = cc.Club.Trainer
                })
                .ToList()
        };

        return championshipDTO;
    }
}
*/