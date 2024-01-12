using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject;

public class Email
{
    private readonly string _value;

    private Email(string value)
    {
        _value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("The email cannot be null, empty or contain blanks.", nameof(email));

        if (email.Length > 40)
            throw new ArgumentException("The email cannot be longer than 40 characters.", nameof(email));

        email = email.ToLower();

        if (!IsValidEmail(email))
            throw new ArgumentException("Invalid email format.", nameof(email));

        return new Email(email);
    }

    public string GetValue()
    {
        return _value;
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
}
