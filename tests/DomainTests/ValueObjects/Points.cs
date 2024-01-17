/*
using Domain.ValueObjects;

namespace tests.DomainTests.ValueObjects;

public class PointsTests
{
    [Fact]
    public void Points_Constructor_Throws_Exception_For_Negative_Values()
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Points(-10));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Points(-1));
    }

    [Fact]
    public void Points_Constructor_Throws_Exception_For_Values_Above_100()
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Points(101));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Points(1000));
    }

    [Fact]
    public void Points_Constructor_Allows_Valid_Values()
    {
        // Arrange
        var points = new Points(50);

        // Assert
        Assert.Equal(50, points.Value);
    }
}
*/