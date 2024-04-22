using Domain.Entities;
using Domain.ValueObject;
using Domain.ValueObjects;

namespace Domain.tests.ValueObjects;

public class BirthDateTests
{
    [Fact]
    public void BirthDate_ValidDate_CreatesObject()
    {
        // Arrange
        DateTime validDate = new DateTime(1990, 1, 1);

        // Act
        BirthDate birthDate = BirthDate.Create(validDate);

        // Assert
        Assert.Equal(validDate, birthDate.Value);
    }

    [Fact]
    public void BirthDate_FutureDate_ThrowsException()
    {
        // Arrange
        DateTime futureDate = DateTime.Now.AddDays(1);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => BirthDate.Create(futureDate));
        Assert.Equal("The date of birth cannot be in the future.", exception.Message);
    }

    [Fact]
    public void BirthDate_InvalidDate_ThrowsException()
    {
        // Arrange
        DateTime invalidDate = new DateTime(1800, 1, 1);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => BirthDate.Create(invalidDate));
        Assert.Equal("The date of birth is invalid.", exception.Message);
    }
}
