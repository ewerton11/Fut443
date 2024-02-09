using Domain.Exceptions;

namespace Domain.ValueObject;

public sealed class UserName : IEquatable<UserName>
{
    public string Value { get; }

    private UserName(string value) => Value = value;

    private UserName() { }

    public static UserName Create(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new InvalidUserNameDomainException($"{nameof(userName)}, The username cannot be null, empty or contain blanks.");

        if (userName.Length > 15)
            throw new InvalidUserNameDomainException($"{nameof(userName)}, The username cannot be longer than 15 characters.");

        if (userName.Length < 3)
            throw new InvalidUserNameDomainException($"{nameof(userName)}, The username cannot be less than 3 characters.");

        foreach (char caractere in userName)
        {
            if (!char.IsLetterOrDigit(caractere))
            {
                throw new InvalidUserNameDomainException($"{nameof(userName)}, The username must contain only letters and numbers.");
            }
        }

        return new UserName(userName);
    }

    public bool Equals(UserName? userName)
    {
        if (userName == null)
            return false;

        return string.Equals(Value, userName.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
    }
}
