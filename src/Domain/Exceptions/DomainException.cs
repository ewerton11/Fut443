namespace Fut443.Domain.Exceptions;

public abstract class DomainException : Exception
{
    public DomainException(string message)
        : base(message)
    {
    }
}
