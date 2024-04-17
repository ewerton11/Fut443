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
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Create_InvalidName_ThrowsInvalidTeamNameDomainException(string invalidName)
    {
        // Act & Assert
        Assert.Throws<InvalidTeamNameDomainException>(() => TeamName.Create(invalidName));
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
