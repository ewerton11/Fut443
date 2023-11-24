using Domain.Entities;
using Domain.ValueObjects;

namespace tests.DomainTests.Entities;

public class UserTests
{
    [Fact]
    public void User_Creation_Succeeds_With_Valid_Arguments()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        string name = "Ewerton Reis";
        string email = "ewerton@email.com";
        string password = "password";
        string userName = "ewerton";
        string role = "user";
        Points points = new Points(100);
        int ranking = 1;
        int futCoins = 50;

        // Act
        var user = new User(userId, name, email, password, userName, role, points, ranking, futCoins);

        // Assert
        Assert.Equal(userId, user.Id);
        Assert.Equal(name, user.Name);
        Assert.Equal(email, user.Email);
        Assert.Equal(password, user.Password);
        Assert.Equal(userName, user.UserName);
        Assert.Equal(role, user.Role);
        Assert.Equal(points, user.Points);
        Assert.Equal(ranking, user.Ranking);
        Assert.Equal(futCoins, user.FutCoins);
    }
}

