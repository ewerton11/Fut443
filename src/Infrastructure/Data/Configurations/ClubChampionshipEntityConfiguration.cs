using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ClubChampionshipEntityConfiguration : IEntityTypeConfiguration<ClubChampionship>
{
    public void Configure(EntityTypeBuilder<ClubChampionship> builder)
    {
        builder.HasKey(cc => new { cc.ClubId, cc.ChampionshipId });

        builder.HasOne(cc => cc.Club)
               .WithMany(c => c.ClubChampionships)
               .HasForeignKey(cc => cc.ClubId);

        builder.HasOne(cc => cc.Championship)
               .WithMany(ch => ch.ClubChampionships)
               .HasForeignKey(cc => cc.ChampionshipId);
    }
}
