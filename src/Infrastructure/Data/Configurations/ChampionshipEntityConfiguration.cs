using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ChampionshipEntityConfiguration : IEntityTypeConfiguration<ChampionshipEntity>
{
    public void Configure(EntityTypeBuilder<ChampionshipEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired();

        builder.Property(c => c.TotalRounds)
            .IsRequired();

        builder.Property(c => c.CurrentPhase);

        builder.Property(c => c.Season)
            .IsRequired();

        builder.Property(c => c.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(c => c.StartDate)
            .IsRequired();

        builder.Property(c => c.EndDate)
            .IsRequired();
    }
}
