using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class MatchEntityConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.MatchDate)
                .IsRequired();

        builder.Property(m => m.HomeTeamScore)
            .IsRequired();

        builder.Property(m => m.AwayTeamScore)
            .IsRequired();

        builder.Property(m => m.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.HasOne(m => m.Round)
            .WithMany(r => r.Matches)
            .HasForeignKey(m => m.RoundId);

        builder.HasOne(m => m.HomeTeam)
               .WithMany(t => t.Matches)
               .HasForeignKey(m => m.HomeTeamId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.AwayTeam)
               .WithMany()
               .HasForeignKey(m => m.AwayTeamId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
