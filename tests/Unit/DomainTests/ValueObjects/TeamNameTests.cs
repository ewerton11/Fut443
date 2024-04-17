using Domain.Exceptions;
using Domain.ValueObjects;

namespace tests.Unit.DomainTests.ValueObjects;

public class TeamNameTests
{

    [Fact]
    public void Create_ValidName_ReturnsTeamNameObject()
    {
        // Arrange
        string validName = "MyTeam";

        // Act
        var teamName = TeamName.Create(validName);

        // Assert
        Assert.NotNull(teamName);
        Assert.Equal(validName, teamName.Value);
    }

    [Theory]
    [InlineData(null, "name, The team name cannot be null, empty or contain blanks.")]
    [InlineData("", "name, The team name cannot be null, empty or contain blanks.")]
    [InlineData("   ", "name, The team name cannot be null, empty or contain blanks.")]
    public void Create_InvalidName_ThrowsException(string name, string expectedErrorMessage)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<InvalidTeamNameDomainException>(() => TeamName.Create(name));

        // Assert
        Assert.Equal(expectedErrorMessage, exception.Message);
    }

    [Fact]
    public void Create_LongName_ThrowsInvalidTeamNameDomainException()
    {
        // Arrange
        string longName = "ThisIsAReallyLongTeamName";

        // Act & Assert
        Assert.Throws<InvalidTeamNameDomainException>(() => TeamName.Create(longName));
    }

    [Fact]
    public void Create_ShortName_ThrowsInvalidTeamNameDomainException()
    {
        // Arrange
        string shortName = "A";

        // Act & Assert
        Assert.Throws<InvalidTeamNameDomainException>(() => TeamName.Create(shortName));
    }
}
