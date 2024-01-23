using Fut443.Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class InvalidPasswordDomainException : DomainException
{
    public InvalidPasswordDomainException(string message) : base(message)
    {
    }
}
