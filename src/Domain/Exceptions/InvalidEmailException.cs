using Fut443.Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class InvalidEmailDomainException : DomainException
{
    public InvalidEmailDomainException(string message) : base(message)
    {
    }
}
