using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class PlayerEntity : BaseEntity
{
    public string Name { get; private set; } = null!;

    public PlayerPosition Position { get; private set; }

    public AvailabilityStatus Status { get; private set; }

    public PlayerParticipationStatus Participation { get; private set; }

    public string? Club { get; private set; }

    public bool Available { get; private set; } = false;

    public Guid? ClubId { get; private set; }
    public ClubEntity? ClubEntity { get; private set; }

    //public decimal? Points { get; private set; }

    // General Statistics
    public int SuccessfulPasses { get; private set; }
    public int DecisivePasses { get; private set; }
    public int Cross { get; private set; }
    public int LongBalls { get; private set; }
    public int GroundDuels { get; private set; }
    public int AerialDuels { get; private set; }
    public int BallLoss { get; private set; }
    public int Fouls { get; private set; }
    public int FoulsSuffered { get; private set; }

    // Attack Statistics
    public int Goals { get; private set; }
    public int Assists { get; private set; }
    public int CompletionsInGoal { get; private set; }
    public int CompletionsForOut { get; private set; }
    public int MissedChances { get; private set; }

    // Defense Statistics
    public int DefenseCuts { get; private set; }
    public int BlockedKicks { get; private set; }
    public int Interceptions { get; private set; }
    public int Disarm { get; private set; }
    public int YellowCards { get; private set; }
    public int RedCards { get; private set; }

    // Goalkeeper Statistics
    public int Defense { get; private set; }
    public int DefensesWithinTheArea { get; private set; }
    public int Punches { get; private set; }
    public int AerialBallsClaimed { get; private set; }

    private PlayerEntity() { }

    public static PlayerEntity Create(string name, string position, AvailabilityStatus status,  Guid? clubId,
        AdminLevel currentAdminLevel)
    {
        if (currentAdminLevel < AdminLevel.HighAdmin)
        {
            throw new UnauthorizedAccessException("Only high-level admins can create player.");
        }

        //o jogador nao pode ja existir
        //nome nao pode ser null
        //posiçãoo nao pode ser null

        if (!Enum.TryParse(position, out PlayerPosition playerPosition))
        {
            throw new ArgumentException("Invalid player position.");
        }

        var player = new PlayerEntity
        {
            Name = name,
            Position = playerPosition,
            Status = status,
            Participation = PlayerParticipationStatus.NotLikely,
            ClubId = clubId,
        };

        return player;
    }
}

