using Domain.Exceptions;

namespace Domain.ValueObject;

public sealed class Password
{
    public string Value { get; }

    private Password(string value) => Value = value;

    private Password() { }

    public static Password Create(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new InvalidPasswordDomainException($"{nameof(password)}, The password cannot be null or empty.");

        if (password.Length > 30)
            throw new InvalidPasswordDomainException($"{nameof(password)}, The password cannot be longer than 30 characters.");

        if (password.Length < 8)
            throw new InvalidPasswordDomainException($"{nameof(password)}, The password cannot be less than 8 characters long.");

        return new Password(password);
    }
}
