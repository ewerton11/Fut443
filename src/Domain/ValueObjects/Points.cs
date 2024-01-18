using Domain.Exceptions;

namespace Domain.ValueObject;

public class Points
{
    public int Value { get; }

    public Points(int value = 0)
    {
        if (value < 0)
        {
            throw new NegativeScoreDomainException($"{nameof(value)}, The score cannot be negative.");
        }
        Value = value;
    }
}

