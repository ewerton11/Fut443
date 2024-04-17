using Domain.Aggregates;
using Domain.Entities;
using Domain.Services.Interfaces;
using Domain.ValueObject;

namespace tests.Unit.DomainTests.Entities
{
    public class UserTests
    {
        [Fact]
        public void HasTeamForChampionship_ReturnsTrue_WhenUserHasTeamForChampionship()
        {
            // Arrange
            var userName = UserName.Create("ewerton");
            var email = Email.Create("ewerton@email.com");
            var passwordHash = "***ewerton123###";

            var user = UserEntity.Create(userName, email, passwordHash);

            var name = "Team Name";
            var userId = Guid.NewGuid();
            var championshipId = Guid.NewGuid();

            var championshipServiceMock = new Mock<IChampionshipService>();
            championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                                   .ReturnsAsync(true);

            var team = Team.Create(user, name, userId, championshipId, championshipServiceMock.Object);
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
            var userName = UserName.Create("ewerton");
            var email = Email.Create("ewerton@email.com");
            var passwordHash = "***ewerton123###";

            var user = UserEntity.Create(userName, email, passwordHash);

            var name = "Team Name";
            var userId = Guid.NewGuid();
            var championshipId = Guid.NewGuid();

            var championshipServiceMock = new Mock<IChampionshipService>();
            championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                                   .ReturnsAsync(true);

            var existingTeam = Team.Create(user, name, userId, Guid.NewGuid(), championshipServiceMock.Object);
            user.Teams.Add(existingTeam);

            // Act
            bool hasTeam = user.HasTeamForChampionship(championshipId);

            // Assert
            Assert.False(hasTeam);
        }
    }
}
