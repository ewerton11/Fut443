﻿using Fut443.Domain.Exceptions;

namespace Domain.Exceptions;

public sealed class NegativeScoreDomainException : DomainException
{
    public NegativeScoreDomainException(string message) : base(message)
    {
    }
}
