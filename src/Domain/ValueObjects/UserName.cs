using Domain.Exceptions;

namespace Domain.ValueObject;

public sealed class UserName
{
    public string Value { get; }

    private UserName(string value) => Value = value;

    public static UserName Create(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new InvalidNameDomainException($"{nameof(userName)}, The name cannot be null, empty or contain blanks.");

        if (userName.Length > 15)
            throw new InvalidNameDomainException($"{nameof(userName)}, The name cannot be longer than 15 characters.");

        if (userName.Length < 3)
            throw new InvalidNameDomainException($"{nameof(userName)}, The name cannot be less than 3 characters.");

        foreach (char caractere in userName)
        {
            if (!char.IsLetterOrDigit(caractere))
            {
                throw new InvalidNameDomainException($"{nameof(userName)}, The username must contain only letters and numbers.");
            }
        }

        return new UserName(userName);
    }
}
