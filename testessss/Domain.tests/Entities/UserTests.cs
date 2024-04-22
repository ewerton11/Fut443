using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObject;
using Domain.ValueObjects;

namespace tests.Unit.DomainTests.Entities
{
    public class UserTests
    {
        private UserEntity CreateUser(DateTime birthday)
        {
            var birthDateResult = BirthDate.Create(birthday);

            var firstName = FirstName.Create("first");
            var lastName = LastName.Create("last");
            var userName = UserName.Create("name");
            var email = Email.Create("name@email.com");
            var passwordHash = "***123###";

            return UserEntity.Create(firstName, lastName, birthDateResult, userName, email, passwordHash);
        }

        private Team CreateTeam(UserEntity user, string name, Guid championshipId)
        {
            return Team.Create(user, name, championshipId);
        }

        [Fact]
        public void IsAdult_ValidBirthday_ReturnsTrue()
        {
            // Arrange
            var birthday = new DateTime(2000, 12, 1);
            var user = CreateUser(birthday);

            // Act
            var isAdult = user.IsAdult();

            // Assert
            Assert.True(isAdult);
        }

        [Fact]
        public void IsAdult_InvalidBirthday_ReturnsFalse()
        {
            // Arrange
            var birthday = DateTime.Now.AddYears(-15);
            var user = CreateUser(birthday);

            // Act
            var isAdult = user.IsAdult();

            // Assert
            Assert.False(isAdult);
        }

        [Fact]
        public void HasTeamForChampionship_ReturnsTrue_WhenUserHasTeamForChampionship()
        {
            // Arrange
            var birthday = new DateTime(2000, 12, 1);
            var user = CreateUser(birthday);

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
            var birthday = new DateTime(2000, 12, 1);
            var user = CreateUser(birthday);

            var existingTeam = CreateTeam(user, "Fluminense", Guid.NewGuid());
            user.Teams.Add(existingTeam);

            // Act
            bool hasTeam = user.HasTeamForChampionship(Guid.NewGuid());

            // Assert
            Assert.False(hasTeam);
        }
    }
}
