using Domain.ValueObjects;

namespace Domain.tests.ValueObjects;

public class FirstNameTests
{
    [Fact]
    public void Create_ValidFirstName_ReturnsFirstNameObject()
    {
        // Arrange
        string validName = "Name";

        // Act
        var firstName = FirstName.Create(validName);

        // Assert
        Assert.Equal(validName, firstName.Value);
    }

    [Theory]
    [InlineData("", "The first name cannot be empty.")]
    [InlineData(null, "The first name cannot be empty.")]
    [InlineData("N", "The first name must be at least 2 characters long.")] 
    [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", "The first name must have a maximum of 30 characters.")]
    [InlineData("123", "The first name must contain only letters.")]
    [InlineData("Name123", "The first name must contain only letters.")]
    [InlineData("First Name", "The first name must contain only letters.")]
    public void Create_InvalidFirstName_ThrowsArgumentException(string invalidName, string expectedErrorMessage)
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(invalidName));

        // Assert
        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}
