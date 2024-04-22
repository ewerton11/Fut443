namespace Domain.ValueObjects;

public class FirstName
{
    private const string AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private const int MinLength = 2;
    private const int MaxLength = 30;
    public string Value { get; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static FirstName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("The first name cannot be empty.");
        }

        if (value.Length < MinLength)
        {
            throw new ArgumentException($"The first name must be at least {MinLength} characters long.");
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"The first name must have a maximum of {MaxLength} characters.");
        }

        if (!value.All(c => AllowedCharacters.Contains(c)))
        {
            throw new ArgumentException("The first name must contain only letters.");
        }

        return new FirstName(value);
    }
}

