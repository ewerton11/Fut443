using Domain.Entities;
using Domain.Interface;
using Domain.Interface.Repository;
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

        var mockPoints = new Mock<Points>();

        var user = new User(
            Guid.NewGuid(),
            "Ewerton Reis",
            "ewerton@email.com",
            "password",
            "ewerton",
            "user",
            mockPoints.Object,
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

