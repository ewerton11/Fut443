using Domain.Aggregates;
using Domain.Entities;
using Domain.Enums;
using Domain.Services.Interfaces;
using Domain.ValueObject;

namespace tests.Unit.DomainTests.Entities
{
    public class UserTests
    {
        private UserEntity CreateUser()
        {
            var userName = UserName.Create("ewerton");
            var email = Email.Create("ewerton@email.com");
            var passwordHash = "***ewerton123###";
            return UserEntity.Create(userName, email, passwordHash);
        }

        private Team CreateTeam(UserEntity user, string name, Guid championshipId)
        {
            return Team.Create(user, name, championshipId);
        }

        [Fact]
        public void HasTeamForChampionship_ReturnsTrue_WhenUserHasTeamForChampionship()
        {
            // Arrange
            var user = CreateUser();

            var championshipId = Guid.NewGuid();

            var team = CreateTeam(user, "Fluminense", championshipId);

            user.Teams.Add(team);

            // Act
            bool hasTeam = user.HasTeamForChampionship(championshipId);

            // Assert
            Assert.True(hasTeam);
        }

        [Fact]
        public void HasTeamForChampionship_ReturnsFalse_WhenUserDoesNotHaveTeamForChampionship()
        {
            // Arrange
            var user = CreateUser();

            var existingTeam = CreateTeam(user, "Fluminense", Guid.NewGuid());
            user.Teams.Add(existingTeam);

            // Act
            bool hasTeam = user.HasTeamForChampionship(Guid.NewGuid());

            // Assert
            Assert.False(hasTeam);
        }
    }
}
