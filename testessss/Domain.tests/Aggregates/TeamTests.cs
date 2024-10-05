using Domain.Aggregates;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.ValueObject;
using Domain.ValueObjects;

namespace Domain.tests.Aggregates;

public class TeamTests
{
    private UserEntity CreateUser()
    {
        var birthDateResult = BirthDate.Create(new DateTime(2000, 12, 1));

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

    private PlayerEntity CreatePlayer(string playerName, string position, SpecificPosition specificPosition, AvailabilityStatus status, string? clubName, Guid clubId, AdminLevel adminLevel)
    {
        return PlayerEntity.Create(playerName, position, specificPosition, status, clubName, clubId, adminLevel);
    }

    [Fact]
    public void CreateTeam_ShouldCreateTeam_WhenValidParameters()
    {
        // Arrange
        var user = CreateUser();

        var championshipId = Guid.NewGuid();

        // Act
        var team = CreateTeam(user, "Fluminense", championshipId);

        // Assert
        Assert.NotNull(team);
        Assert.Equal("Fluminense", team.Name.Value);
        Assert.Equal(championshipId, team.ChampionshipId);
    }

    [Fact]
    public void CreateTeam_ShouldThrowArgumentException_WhenUserHasTeamForChampionship()
    {
        // Arrange
        var user = CreateUser();

        var championshipId = Guid.NewGuid();

        // Act
        var existingTeam = CreateTeam(user, "Fluminense", championshipId);
        user.Teams.Add(existingTeam);

        // Assert
        var exception = Assert.Throws<ArgumentException>(() => CreateTeam(user, "name team", championshipId));
        Assert.Equal("The user already has a team for this championship.", exception.Message);
    }

    [Fact]
    public void CreateTeamName_ShouldInvalidTeamName_ThrowsArgumentException()
    {
        // Arrange
        var user = CreateUser();

        var name = "";

        // Act & Assert
        Assert.Throws<InvalidTeamNameDomainException>(() => CreateTeam(user, name, Guid.NewGuid()));
    }

    [Fact]
    public void AddPlayer_ShouldAddPlayerToTeam_WhenValidPlayerAndChampionship()
    {
        // Arrange
        var user = CreateUser();

        //var championshipId = Guid.NewGuid();

        var team = CreateTeam(user, "fluzao", Guid.NewGuid());
        var player = CreatePlayer("Gaman cano", "Attacker", SpecificPosition.ST, AvailabilityStatus.Available, null, Guid.NewGuid(), AdminLevel.HighAdmin);

        // Act
        team.AddPlayer(player);

        // Assert
        Assert.Contains(player, team.Players);
    }

    [Theory]
    [InlineData(PlayerPosition.Attacker, "O time já possui o máximo de atacantes permitidos.", 3)]
    [InlineData(PlayerPosition.Midfielder, "O time já possui o máximo de meio-campistas permitidos.", 3)]
    [InlineData(PlayerPosition.Defender, "O time já possui o máximo de zagueiros permitidos.", 4)]
    [InlineData(PlayerPosition.Goalkeeper, "O time já possui o máximo de goleiros permitidos.", 1)]
    public void AddPlayer_MaxPlayers_ExceptionThrown(PlayerPosition playerPosition, string expectedErrorMessage, int maxPlayers)
    {
        // Arrange
        var user = CreateUser();

        var team = CreateTeam(user, "Fluzao", Guid.NewGuid());

        var players = new List<PlayerEntity>();

        // Create players based on the maximum allowed for the given type
        for (int i = 1; i <= maxPlayers; i++)
        {
            var playerName = $"{playerPosition}{i}";
            var player = CreatePlayer(playerName, $"{playerPosition}", SpecificPosition.ST, AvailabilityStatus.Available, null, Guid.NewGuid(), AdminLevel.HighAdmin);
            players.Add(player);
        }

        foreach (var player in players)
        {
            team.AddPlayer(player);
        }

        // Act & Assert
        var newPlayer = CreatePlayer("New Player", $"{playerPosition}", SpecificPosition.ST, AvailabilityStatus.Available, null, Guid.NewGuid(), AdminLevel.HighAdmin);

        var exception = Assert.Throws<ApplicationException>(() => team.AddPlayer(newPlayer));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void AddPlayer_PlayerAlreadyInTeam_ThrowsException()
    {
        // Arrange
        var user = CreateUser();

        var player = CreatePlayer("German Cano", "Attacker", SpecificPosition.ST, AvailabilityStatus.Available, null, Guid.NewGuid(), AdminLevel.HighAdmin);

        var team = CreateTeam(user, "Fluminense", Guid.NewGuid());

        team.AddPlayer(player);

        // Act e Assert
        var exception = Assert.Throws<ApplicationException>(() => team.AddPlayer(player));
        Assert.Equal("O jogador ja existe nesse time.", exception.Message);
    }

    [Fact]
    public void AddPlayer_PlayerNotAvailable_ThrowException()
    {
        // Arrange
        var user = CreateUser();

        var player = CreatePlayer("German Cano", "Attacker", SpecificPosition.ST, AvailabilityStatus.Unavailable, null, Guid.NewGuid(), AdminLevel.HighAdmin);

        var team = CreateTeam(user, "fluzao", Guid.NewGuid());

        // Act e Assert
        var exception = Assert.Throws<ApplicationException>(() => team.AddPlayer(player));
        Assert.Equal("Jogador não disponivel.", exception.Message);
    }

    [Theory]
    [InlineData(PlayerPosition.Attacker, "O time já possui o máximo de atacantes permitidos.", 3)]
    [InlineData(PlayerPosition.Midfielder, "O time já possui o máximo de meio-campistas permitidos.", 3)]
    [InlineData(PlayerPosition.Defender, "O time já possui o máximo de zagueiros permitidos.", 4)]
    [InlineData(PlayerPosition.Goalkeeper, "O time já possui o máximo de goleiros permitidos.", 1)]
    public void AddPlayer_MaximumPlayers_ThrowException(PlayerPosition playerPosition, string expectedErrorMessage, int maxPlayers)
    {
        // Arrange
        var user = CreateUser();

        var players = new List<PlayerEntity>();

        // Create players
        for (int i = 1; i <= maxPlayers; i++)
        {
            var playerName = $"{playerPosition}{i}";
            var player = CreatePlayer(playerName, $"{playerPosition}", SpecificPosition.ST, AvailabilityStatus.Available, null, Guid.NewGuid(), AdminLevel.HighAdmin);
            players.Add(player);
        }

        var team = CreateTeam(user, "Fluminense", Guid.NewGuid());

        foreach (var player in players)
        {
            team.AddPlayer(player);
        }

        var newPlayer = CreatePlayer("Name player", $"{playerPosition}", SpecificPosition.ST, AvailabilityStatus.Available, null, Guid.NewGuid(), AdminLevel.HighAdmin);

        // Assert
        var exception = Assert.Throws<ApplicationException>(() => team.AddPlayer(newPlayer));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}
