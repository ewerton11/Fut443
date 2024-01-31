using Domain.Exceptions;

namespace Domain.ValueObject;

public class Email : IEquatable<Email>
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

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

    public bool Equals(Email? other)
    {
        // Verifique se o outro objeto não é nulo
        if (ReferenceEquals(null, other)) return false;

        // Verifique se os objetos têm o mesmo valor
        return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;

        return obj is Email other && Equals(other);
    }

    public override int GetHashCode()
    {
        // Use um hashcode sensato para o valor
        return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
    }
}
