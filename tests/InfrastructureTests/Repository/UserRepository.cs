/*
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.ValueObject;
using Domain.ValueObjects;
using Infrastructure.Repository;

namespace tests.InfrastructureTests.Repository;

public class UserRepositoryTests
{
    [Fact]
    public async Task CreateAsync_User_CallsBaseRepositoryCreateAsync()
    {
        // Arrange
        var mockBaseRepository = new Mock<IBaseRepository<User>>();
        var userRepository = new UserRepository(mockBaseRepository.Object);

        var userName = UserName.Create("Ewerton");
        var email = Email.Create("ewerton@email.com");
        var points = new Points(100);

        var user = new User(
           userName,
           email,
           "password",
           "user",
           points,
           1,
           100
        );

        mockBaseRepository
            .Setup(repo => repo.CreateAsync(user))
            .Returns(Task.CompletedTask);

        // Act
        await userRepository.CreateAsync(user);

        // Assert
        mockBaseRepository.Verify(repo => repo.CreateAsync(user), Times.Once);
    }
}
*/