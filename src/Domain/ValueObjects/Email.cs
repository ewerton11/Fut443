using Domain.Exceptions;

namespace Domain.ValueObject;

public class Email
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
}
