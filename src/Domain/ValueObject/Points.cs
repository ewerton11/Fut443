namespace Domain.ValueObjects;

public class Points : IEquatable<Points>
{
    public int Value { get; }

    public Points(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("A pontuação não pode ser negativa.");
        }
        Value = value;
    }

    public bool Equals(Points? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Points other)
        {
            return Equals(other);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}

