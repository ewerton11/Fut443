using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .HasConversion(
                v => v.Value,
                v => TeamName.Create(v)
            );

        builder.HasOne(t => t.User)
            .WithMany(u => u.Teams)
            .HasForeignKey(t => t.UserId);

        builder.HasOne(t => t.Championship)
            .WithMany()
            .HasForeignKey(t => t.ChampionshipId);
    }
}
