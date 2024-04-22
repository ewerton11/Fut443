using Domain.ValueObjects;

namespace Domain.tests.ValueObjects;

public class LastNameTests
{
    [Fact]
    public void Create_ValidLastName_ReturnsLastNameObject()
    {
        // Arrange
        string validName = "LastName";

        // Act
        var lastName = LastName.Create(validName);

        // Assert
        Assert.Equal(validName, lastName.Value);
    }

    [Theory]
    [InlineData("", "The last name cannot be empty.")]
    [InlineData(null, "The last name cannot be empty.")]
    [InlineData("N", "The last name must be at least 2 characters long.")]
    [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", "The last name must have a maximum of 30 characters.")]
    [InlineData("123", "The last name must contain only letters.")]
    [InlineData("Name123", "The last name must contain only letters.")]
    [InlineData("Last Name", "The last name must contain only letters.")]
    public void Create_InvalidLastName_ThrowsArgumentException(string invalidName, string expectedErrorMessage)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => LastName.Create(invalidName));

        // Assert
        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}
