namespace Domain.ValueObject;

public class Name : IEquatable<Name>
{
    private readonly string _value;

    private Name(string value)
    {
        _value = value;
    }

    public static Name Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentException("The name cannot be null, empty or contain blanks.", nameof(name));

        if(name.Length > 15 ) 
            throw new ArgumentException("The name cannot be longer than 15 characters.", nameof(name));

        if (name.Length < 3) 
            throw new ArgumentException("The name cannot be less than 3 characters.", nameof(name));

        return new Name(name);
    }

    public string GetValue()
    {
        return _value;
    }

    public bool ContainsOnlyLetters()
    {
        foreach (char caractere in _value)
        {
            if (!char.IsLetter(caractere))
            {
                return false;
            }
        }
        return true;
    }

    public bool Equals(Name? other)
    {
        if (other is null)
            return false;

        return _value.Equals(other._value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}
