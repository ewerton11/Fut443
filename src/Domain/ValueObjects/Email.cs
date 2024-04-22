using Domain.Exceptions;

namespace Domain.ValueObject;

public class Email : IEquatable<Email>
{
    public string Value { get; } = null!;

    private Email(string value)
    {
        Value = value;
    }

    private Email() { }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new InvalidEmailDomainException($"{nameof(email)}, The email cannot be null, empty or contain blanks.");

        if (email.Length > 40)
            throw new InvalidEmailDomainException($"{nameof(email)}, The email cannot be longer than 40 characters.");

        email = email.ToLower();

        if (!IsValidEmail(email))
            throw new InvalidEmailDomainException($"{nameof(email)}, Invalid email format.");

        return new Email(email);
    }

    public bool Equals(Email? email)
    {
        if (email == null)
            return false;

        return string.Equals(Value, email.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
    }
}
