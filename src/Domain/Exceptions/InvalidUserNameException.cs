using Fut443.Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class InvalidUserNameDomainException : DomainException
{
    public InvalidUserNameDomainException(string message) : base(message)
    {
    }
}
