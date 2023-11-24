using Domain.Entities;

namespace Domain.Tests.Entities;

public class AdministratorTests
{
    [Fact]
    public void Administrator_Can_Be_Created_With_Correct_Parameters()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        string name = "Ewerton Reis";
        string email = "ewerton@email.com";
        string password = "password";
        string userName = "ewerton";
        string role = "admin";

        // Act
        var administrator = new Administrator(id, name, email, password, userName, role);

        // Assert
        Assert.Equal(id, administrator.Id);
        Assert.Equal(name, administrator.Name);
        Assert.Equal(email, administrator.Email);
        Assert.Equal(password, administrator.Password);
        Assert.Equal(userName, administrator.UserName);
        Assert.Equal(role, administrator.Role);
    }
}
