using Domain.Enums;

namespace Domain.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public PositionType Position { get; private set; }

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

        public static PlayerEntity Create(string name, PositionType position)
        {
            var player = new PlayerEntity
            {
                Name = name,
                Position = position
            };

            return player;
        }
    }
}

