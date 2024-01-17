namespace Domain.ValueObject;

public class Role
{
    private readonly string _value;

    public string Value => string.IsNullOrEmpty(_value) ? "user" : _value;

    private Role(string value)
    {
        _value = value;
    }
}
