﻿using Domain.Entities;
using Domain.ValueObject;

namespace Domain.Tests.Entities;

public class AdministratorTests
{
    [Fact]
    public void Administrator_Can_Be_Created_With_Correct_Parameters()
    {
        // Arrange
        UserName userName = UserName.Create("ewerton");
        Email email = Email.Create("ewerton@email.com");
        string password = "password";

        // Act
        var administrator = new Administrator(userName, email, password);

        // Assert
        Assert.Equal(userName, administrator.UserName);
        Assert.Equal(email, administrator.Email);
        Assert.Equal(password, administrator.Password);
    }
}
