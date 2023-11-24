namespace Domain.ValueObjects;

public class Points
{
    public int Value { get; }

    public Points()
    {
    }

    public Points(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Points cannot be negative.");

        if (value > 100)
            throw new ArgumentOutOfRangeException(nameof(value), $"Points cannot exceed {100}.");

        Value = value;
    }
}
