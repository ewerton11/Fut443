using Domain.Exceptions;

namespace Domain.ValueObjects;

public class TeamName
{
    public string Value { get; }

    private TeamName(string value) => Value = value;

    public static TeamName Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidTeamNameDomainException($"{nameof(name)}, The team name cannot be null, empty or contain blanks.");

        if (name.Length > 15)
            throw new InvalidTeamNameDomainException($"{nameof(name)}, The team name cannot be longer than 15 characters.");

        if (name.Length < 2)
            throw new InvalidTeamNameDomainException($"{nameof(name)}, The team name cannot be less than 2 characters.");

        return new TeamName(name);
    }
}
