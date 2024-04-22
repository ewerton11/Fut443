namespace Domain.ValueObjects;

public class LastName
{
    private const string AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private const int MinLength = 2;
    private const int MaxLength = 30;
    public string Value { get; }

    private LastName(string value)
    {
        Value = value;
    }

    public static LastName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("The last name cannot be empty.");
        }

        if (value.Length < MinLength)
        {
            throw new ArgumentException($"The last name must be at least {MinLength} characters long.");
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"The last name must have a maximum of {MaxLength} characters.");
        }

        if (!value.All(c => AllowedCharacters.Contains(c)))
        {
            throw new ArgumentException("The last name must contain only letters.");
        }

        return new LastName(value);
    }
}


