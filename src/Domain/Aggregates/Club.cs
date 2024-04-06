using Domain.Entities.Base;

namespace Domain.Aggregates;

public class Club : BaseEntity
{
    public string Name { get; private set; }

    //players

    private Club() { }
}
