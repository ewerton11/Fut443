using Domain.Aggregates;
using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class ClubEntity : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public List<PlayerEntity> Players { get; private set; } = new List<PlayerEntity>();
    public string Trainer { get; private set; } = null!;
    public List<ClubChampionship>? ClubChampionships { get; private set; }
    public List<Match>? Matches { get; private set; }

    private ClubEntity() { }

    public static ClubEntity Create(string name, string country, string trainer, AdminLevel currentAdminLevel)
    {
        //apenas admin nivel 2 e acima pode criar
        //mudar mensagem
        if (currentAdminLevel < AdminLevel.HighAdmin)
        {
            throw new ArgumentException("New admin level cannot be higher or equal to the creating admin's level.");
        }

        //um club não pode ter o mesmo nome de outro club

        var club = new ClubEntity
        {
            Name = name,
            Country = country,
            Trainer = trainer,
        };

        return club;
    }
}
