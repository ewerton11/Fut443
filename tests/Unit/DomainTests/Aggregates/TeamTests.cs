using Domain.Aggregates;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Services.Interfaces;
using Domain.ValueObject;

namespace tests.Unit.DomainTests.Aggregates;

public class TeamTests
{
    private UserEntity CreateUser()
    {
        var userName = UserName.Create("ewerton");
        var email = Email.Create("ewerton@email.com");
        var passwordHash = "***ewerton123###";
        return UserEntity.Create(userName, email, passwordHash);
    }

    private Team CreateTeam(UserEntity user, string teamName, Guid userId, Guid championshipId, Mock<IChampionshipService> championshipServiceMock)
    {
        return Team.Create(user, teamName, userId, championshipId, championshipServiceMock.Object);
    }

    private PlayerEntity CreatePlayer(string playerName, string position, AvailabilityStatus status, Guid clubId, AdminLevel adminLevel)
    {
        return PlayerEntity.Create(playerName, position, status, clubId, adminLevel);
    }

    [Fact]
    public void CreateTeam_ValidUserNoTeamForChampionship_CreatesTeam()
    {
        // Arrange
        var user = CreateUser();

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                               .ReturnsAsync(true);

        var userId = Guid.NewGuid();
        var championshipId = Guid.NewGuid();

        var team = CreateTeam(user, "Fluzao", userId, championshipId, championshipServiceMock);

        // Act & Assert
        Assert.NotNull(team);
        Assert.Equal("Fluzao", team.Name.Value);
        Assert.Equal(userId, team.UserId);
        Assert.Equal(championshipId, team.ChampionshipId);
    }

    [Fact]
    public void CreateTeam_UserHasTeamForChampionship_ThrowsArgumentException()
    {
        // Arrange
        var user = CreateUser();

        var userId = Guid.NewGuid();
        var championshipId = Guid.NewGuid();

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                               .ReturnsAsync(true);

        var existingTeam = CreateTeam(user, "name team", userId, championshipId, championshipServiceMock);

        user.Teams.Add(existingTeam);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => CreateTeam(user, "name team", userId, championshipId, championshipServiceMock));
        Assert.Equal("The user already has a team for this championship.", exception.Message);
    }

    [Fact]
    public void CreateTeamName_InvalidTeamName_ThrowsArgumentException()
    {
        // Arrange
        var user = CreateUser();

        var name = "";

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
        .ReturnsAsync(true);

        // Act & Assert
        Assert.Throws<InvalidTeamNameDomainException>(() => CreateTeam(user, name, Guid.NewGuid(), Guid.NewGuid(),
            championshipServiceMock));
    }

    [Fact]
    public async Task AddPlayer_ValidPlayer_PlayerAdded()
    {
        // Arrange
        var user = CreateUser();

        var userId = Guid.NewGuid();
        var championshipId = Guid.NewGuid();

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                               .ReturnsAsync(true);

        var team = CreateTeam(user, "fluzao", Guid.NewGuid(), championshipId, championshipServiceMock);

        var player = CreatePlayer("Gaman cano", "Attacker", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);

        await team.AddPlayer(player, championshipId);

        // Act e Assert
        Assert.Contains(player, team.Players);
    }

    [Fact]
    public async Task AddPlayer_MaxPlayers_ExceptionThrown()
    {
        // Arrange
        var user = CreateUser();

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                               .ReturnsAsync(true);

        var team = CreateTeam(user, "Fluzao", Guid.NewGuid(), Guid.NewGuid(), championshipServiceMock);

        var players = new List<PlayerEntity>();

        // Create 3 attackers
        for (int i = 1; i <= 3; i++)
        {
            var playerName = $"Attacker{i}";
            var player = CreatePlayer(playerName, "Attacker", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);
            players.Add(player);
        }

        // Create 3 midfielders
        for (int i = 1; i <= 3; i++)
        {
            var playerName = $"Midfielder{i}";
            var player = CreatePlayer(playerName, "Midfielder", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);
            players.Add(player);
        }

        // Create 4 defenders
        for (int i = 1; i <= 4; i++)
        {
            var playerName = $"Defender{i}";
            var player = CreatePlayer(playerName, "Defender", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);
            players.Add(player);
        }

        // Create 1 goalkeeper
        var goalkeeper = CreatePlayer("Goalkeeper", "Goalkeeper", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);
        players.Add(goalkeeper);

        foreach (var player in players)
        {
            await team.AddPlayer(player, team.ChampionshipId);
        }

        // Act & Assert
        var player12 = CreatePlayer("Player12", "Attacker", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);

        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => await team.AddPlayer(player12, team.ChampionshipId));
        Assert.Equal("O time já possui o máximo de jogadores permitidos.", exception.Message);
    }

    [Fact]
    public async void AddPlayer_PlayerNotInChampionship_ExceptionThrown()
    {
        // Arrange
        var user = CreateUser();

        var player = CreatePlayer("Gaman cano", "Attacker", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                               .ReturnsAsync(false);

        var team = CreateTeam(user, "fluzao", Guid.NewGuid(), Guid.NewGuid(), championshipServiceMock);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ApplicationException>(async () => await team.AddPlayer(player, Guid.NewGuid()));
        Assert.Equal("O jogador não pertence a essa campeonato.", exception.Message);
    }

    [Fact]
    public async void AddPlayer_PlayerAlreadyInTeam_ThrowsException()
    {
        // Arrange
        var user = CreateUser();

        var player = CreatePlayer("German Cano", "Attacker", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                               .ReturnsAsync(true);

        var team = CreateTeam(user, "fluzao", Guid.NewGuid(), Guid.NewGuid(), championshipServiceMock);

        await team.AddPlayer(player, Guid.NewGuid());

        // Act e Assert
        var exception = await Assert.ThrowsAsync<ApplicationException>(async () => await team.AddPlayer(player, Guid.NewGuid()));
        Assert.Equal("O jogador ja existe nesse time.", exception.Message);
    }

    [Fact]
    public async void AddPlayer_PlayerNotAvailable_ThrowException()
    {
        // Arrange
        var user = CreateUser();

        var player = CreatePlayer("German Cano", "Attacker", AvailabilityStatus.Unavailable, Guid.NewGuid(), AdminLevel.HighAdmin);

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                               .ReturnsAsync(true);

        var team = CreateTeam(user, "fluzao", Guid.NewGuid(), Guid.NewGuid(), championshipServiceMock);

        // Act e Assert
        var exception = await Assert.ThrowsAsync<ApplicationException>(async () => await team.AddPlayer(player, Guid.NewGuid()));
        Assert.Equal("Jogador não disponivel.", exception.Message);
    }

    [Theory]
    [InlineData(PlayerPosition.Attacker, "O time já possui o máximo de atacantes permitidos.", 3)]
    [InlineData(PlayerPosition.Midfielder, "O time já possui o máximo de meio-campistas permitidos.", 3)]
    [InlineData(PlayerPosition.Defender, "O time já possui o máximo de zagueiros permitidos.", 4)]
    [InlineData(PlayerPosition.Goalkeeper, "O time já possui o máximo de goleiros permitidos.", 1)]
    public async Task AddPlayer_MaximumPlayers_ThrowException(PlayerPosition playerPosition, string expectedErrorMessage, int maxAllowed)
    {
        // Arrange
        var user = CreateUser();

        var players = new List<PlayerEntity>();

        // Create players
        for (int i = 1; i <= maxAllowed; i++)
        {
            var playerName = $"{playerPosition}{i}";
            var player = CreatePlayer(playerName, $"{playerPosition}", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);
            players.Add(player);
        }

        var championshipServiceMock = new Mock<IChampionshipService>();
        championshipServiceMock.Setup(service => service.IsPlayerInChampionship(It.IsAny<Guid>(), It.IsAny<Guid>()))
                               .ReturnsAsync(true);

        var team = CreateTeam(user, "fluzao", Guid.NewGuid(), Guid.NewGuid(), championshipServiceMock);

        foreach (var player in players)
        {
            await team.AddPlayer(player, team.ChampionshipId);
        }

        var newPlayer = CreatePlayer("Name player", $"{playerPosition}", AvailabilityStatus.Available, Guid.NewGuid(), AdminLevel.HighAdmin);

        // Assert
        var exception = await Assert.ThrowsAsync<ApplicationException>(async () => await team.AddPlayer(newPlayer, team.ChampionshipId));
        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}
