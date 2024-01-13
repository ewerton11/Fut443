﻿namespace Domain.ValueObjects;

public class Points
{
    public int Value { get; }

    public Points(int value = 0)
    {
        if (value < 0)
        {
            throw new ArgumentException("The score cannot be negative.");
        }
        Value = value;
    }
}

