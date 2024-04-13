using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class CompetitionEntityConfiguration : IEntityTypeConfiguration<Competition>
{
    public void Configure(EntityTypeBuilder<Competition> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title);

        builder.Property(c => c.Value)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(c => c.Championship)
            .WithMany(ch => ch.Competitions)
            .HasForeignKey(c => c.ChampionshipId);
    }
}
