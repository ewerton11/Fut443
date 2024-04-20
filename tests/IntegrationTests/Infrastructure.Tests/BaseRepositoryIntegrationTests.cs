using Domain.Entities;
using Domain.Repository;
using Domain.ValueObject;

namespace tests.IntegrationTests.Infrastructure.Tests;

public class BaseRepositoryIntegrationTests
{
    private UserEntity CreateUser()
    {
        var userName = UserName.Create("ewerton");
        var email = Email.Create("ewerton@email.com");
        var passwordHash = "***ewerton123###";
        return UserEntity.Create(userName, email, passwordHash);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEntity()
    {
        // Arrange
        var mockRepository = new Mock<IBaseRepository<UserEntity>>();

        var user = CreateUser();
        mockRepository.Setup(repo => repo.GetByIdAsync(user.Id)).ReturnsAsync(user);

        // Act
        var result = await mockRepository.Object.GetByIdAsync(user.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
    }
}
