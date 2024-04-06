using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class MatchEntityConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.MatchDate);

        builder.Property(m => m.HomeTeam);

        builder.Property(m => m.AwayTeam);

        builder.Property(m => m.HomeTeamScore);

        builder.Property(m => m.AwayTeamScore);

        builder.Property(m => m.Status);
    }
}
