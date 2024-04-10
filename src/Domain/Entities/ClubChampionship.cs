namespace Domain.Entities;

public class ClubChampionship
{
    public Guid ClubId { get; set; }
    public ClubEntity Club { get; set; } = null!;

    public Guid ChampionshipId { get; set; }
    public ChampionshipEntity Championship { get; set; } = null!;

    private ClubChampionship() { }

    public static ClubChampionship Associate(ClubEntity club, ChampionshipEntity championship)
    {
        var clubChampionship = new ClubChampionship
        {
            ClubId = club.Id,
            Club = club,
            ChampionshipId = championship.Id,
            Championship = championship
        };
        return clubChampionship;
    }
}
