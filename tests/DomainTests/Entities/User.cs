using Domain.Entities;
using Domain.ValueObject;
using Domain.ValueObjects;

namespace tests.DomainTests.Entities;

public class UserTests
{
    [Fact]
    public void User_Creation_Succeeds_With_Valid_Arguments()
    {
        // Arrange
        UserName userName = UserName.Create("ewerton");
        Email email = Email.Create("ewerton@email.com");
        string password = "password";
        Points points = new Points(100);
        int ranking = 1;
        int futCoins = 50;

        // Act
        var user = new User(userName, email, password, points, ranking, futCoins);

        // Assert
        Assert.Equal(userName.GetValue(), user.UserName.GetValue());
        Assert.Equal(email.GetValue(), user.Email.GetValue());
        Assert.Equal(password, user.Password);
        Assert.Equal(points, user.Points);
        Assert.Equal(ranking, user.Ranking);
        Assert.Equal(futCoins, user.FutCoins);
    }
}

