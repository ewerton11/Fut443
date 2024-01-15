namespace Domain.ValueObject;

public sealed class UserName
{
    public string Value { get; }

    private UserName(string value) => Value = value;

    public static UserName Create(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("The name cannot be null, empty or contain blanks.", nameof(userName));

        if (userName.Length > 15)
            throw new ArgumentException("The name cannot be longer than 15 characters.", nameof(userName));

        if (userName.Length < 3)
            throw new ArgumentException("The name cannot be less than 3 characters.", nameof(userName));

        foreach (char caractere in userName)
        {
            if (!char.IsLetterOrDigit(caractere))
            {
                throw new ArgumentException("The username must contain only letters and numbers.", nameof(userName));
            }
        }

        return new UserName(userName);
    }

    public string GetValue()
    {
        return Value;
    }
}
