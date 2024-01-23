using Fut443.Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class InvalidTeamNameDomainException : DomainException
{
    public InvalidTeamNameDomainException(string message) : base(message)
    {
    }
}
