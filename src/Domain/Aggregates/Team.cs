using Domain.Entities.Base;
using Domain.Enums;
using Domain.Services;
using Domain.Services.Interfaces;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Team : BaseEntity
{
    private readonly IChampionshipService _championshipService;

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

    public Team(IChampionshipService championshipService)
    {
        _championshipService = championshipService ?? throw new ArgumentNullException(nameof(championshipService));
    }

    public static Team Create(UserEntity user, string name, Guid userId, Guid championshipId, IChampionshipService championshipService)
    {
        if (user.HasTeamForChampionship(championshipId))
        {
            throw new ArgumentException("The user already has a team for this championship.");
        }

        var teamNameResult = TeamName.Create(name);

        var team = new Team(championshipService)
        {
            Name = teamNameResult,
            UserId = userId,
            ChampionshipId = championshipId
        };

        return team;
    }

    public async Task AddPlayer(PlayerEntity player, Guid championshipId)
    {
        //regra de substituição
        //regra de pontuação
        //regra de capitão

        if (Players.Count >= TotalPlayers)
        {
            throw new ArgumentException("O time já possui o máximo de jogadores permitidos.");
        }

        await ValidatePlayer(player, championshipId);

        Players.Add(player);
    }

    private async Task ValidatePlayer(PlayerEntity player, Guid championshipId)
    {
        bool isInChampionship = await _championshipService.IsPlayerInChampionship(player.Id, championshipId);

        if (!isInChampionship)
        {
            throw new ApplicationException("O jogador não pertence a essa campeonato.");
        }

        if (Players.Any(p => p.Id == player.Id))
        {
            throw new ApplicationException("O jogador ja existe nesse time.");
        }

        if (player.Status != AvailabilityStatus.Available)
        {
            throw new ApplicationException("Jogador não disponivel.");
        }

        int attackerCount = Players.Count(p => p.Position == PlayerPosition.Attacker);
        int midfielderCount = Players.Count(p => p.Position == PlayerPosition.Midfielder);
        int defenderCount = Players.Count(p => p.Position == PlayerPosition.Defender);
        int goalkeeperCount = Players.Count(p => p.Position == PlayerPosition.Goalkeeper);

        if (player.Position == PlayerPosition.Attacker && attackerCount >= TotalAttacker)
        {
            throw new ApplicationException("O time já possui o máximo de atacantes permitidos.");
        }
        else if (player.Position == PlayerPosition.Midfielder && midfielderCount >= TotalMidfielder)
        {
            throw new ApplicationException("O time já possui o máximo de meio-campistas permitidos.");
        }
        else if (player.Position == PlayerPosition.Defender && defenderCount >= TotalDefender)
        {
            throw new ApplicationException("O time já possui o máximo de zagueiros permitidos.");
        }
        else if (player.Position == PlayerPosition.Goalkeeper && goalkeeperCount >= TotalGoalkeeper)
        {
            throw new ApplicationException("O time já possui o máximo de goleiros permitidos.");
        }
    }
}
