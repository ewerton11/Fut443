using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Team : BaseEntity
{
    public TeamName Name { get; private set; } = null!;

    public List<PlayerEntity> Players { get; private set; } = new List<PlayerEntity>();
    private const int TotalPlayers = 11;
    private const int TotalAttacker = 3;
    private const int TotalMidfielder = 3;
    private const int TotalDefender = 4;
    private const int TotalGoalkeeper = 1;

    public Guid UserId { get; private set; }

    public UserEntity User { get; private set; } = null!;

    public Guid ChampionshipId { get; private set; }

    public ChampionshipEntity Championship { get; private set; } = null!;

    private Team() { }

    public static Team Create(UserEntity? user, string? name, Guid championshipId)
    {
        if (user != null && name != null)
        {
            if (user.HasTeamForChampionship(championshipId))
            {
                throw new ArgumentException("The user already has a team for this championship.");
            }

            var teamNameResult = TeamName.Create(name);

            var team = new Team
            {
                Name = teamNameResult,
                UserId = user.Id,
                ChampionshipId = championshipId
            };

            return team;
        }
        else
        {
            var team = new Team
            {
                ChampionshipId = championshipId
            };

            return team;
        }
    }

    public void AddPlayer(PlayerEntity player)
    {
        //regra de substituição
        //regra de pontuação
        //regra de capitão

        if (Players.Count >= TotalPlayers)
        {
            throw new ArgumentException("O time já possui o máximo de jogadores permitidos.");
        }

        ValidatePlayer(player);

        Players.Add(player);
    }

    public List<PlayerEntity> GetPlayers()
    {
        return Players;
    }

    private void ValidatePlayer(PlayerEntity player)
    {
        /*
       bool isInChampionship = await _championshipService.IsPlayerInChampionship(player.Id, championshipId);

       if (!isInChampionship)
       {
           throw new ApplicationException("O jogador não pertence a essa campeonato.");
       }
       */

        if (Players.Any(p => p.Id == player.Id))
        {
            throw new ApplicationException("O jogador ja existe nesse time.");
        }

        if (player.Status != AvailabilityStatus.Available)
        {
            throw new ApplicationException("Jogador não disponivel.");
        }

        ValidatePlayerPositionLimits(player);
    }

    private void ValidatePlayerPositionLimits(PlayerEntity player)
    {
        int attackerCount = Players.Count(p => p.Position == PlayerPosition.Attacker);
        int midfielderCount = Players.Count(p => p.Position == PlayerPosition.Midfielder);
        int defenderCount = Players.Count(p => p.Position == PlayerPosition.Defender);
        int goalkeeperCount = Players.Count(p => p.Position == PlayerPosition.Goalkeeper);

        switch (player.Position)
        {
            case PlayerPosition.Attacker when attackerCount >= TotalAttacker:
                throw new ApplicationException("O time já possui o máximo de atacantes permitidos.");
            case PlayerPosition.Midfielder when midfielderCount >= TotalMidfielder:
                throw new ApplicationException("O time já possui o máximo de meio-campistas permitidos.");
            case PlayerPosition.Defender when defenderCount >= TotalDefender:
                throw new ApplicationException("O time já possui o máximo de zagueiros permitidos.");
            case PlayerPosition.Goalkeeper when goalkeeperCount >= TotalGoalkeeper:
                throw new ApplicationException("O time já possui o máximo de goleiros permitidos.");
        }
    }
}
