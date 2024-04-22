namespace Domain.ValueObjects;

public class BirthDate
{
    public DateTime Value { get; }

    private BirthDate(DateTime value) => Value = value;

    private BirthDate() { }

    public static BirthDate Create(DateTime value)
    {
        if (value > DateTime.Now)
            throw new ArgumentException("The date of birth cannot be in the future.");

        if (value < DateTime.Now.AddYears(-150))
            throw new ArgumentException("The date of birth is invalid.");

        return new BirthDate(value);
    }
}

