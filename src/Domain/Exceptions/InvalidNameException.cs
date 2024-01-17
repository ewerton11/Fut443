using Gatherly.Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class InvalidNameDomainException : DomainException
{
    public InvalidNameDomainException(string message) : base(message)
    {
    }
}
