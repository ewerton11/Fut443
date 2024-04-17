using Domain.Aggregates;
using Domain.Entities.Base;
using Domain.ValueObject;

namespace Domain.Entities
{
    public class UserEntity : BaseUserEntity
    {
        public UserName UserName { get; private set; } = null!;

        public List<Team> Teams { get; private set; } = new List<Team>();

        private UserEntity() { }

        public static UserEntity Create(UserName userName, Email email, string passwordHash)
        {
            var user = new UserEntity
            {
                FirstName = string.Empty,
                UserName = userName,
                Email = email,
                PasswordHash = passwordHash
            };

            return user;
        }

        public bool HasTeamForChampionship(Guid championshipId)
        {
            return Teams.Any(team => team.ChampionshipId == championshipId);
        }
    }
}
