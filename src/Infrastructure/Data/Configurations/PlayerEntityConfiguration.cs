using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class PlayerEntityConfiguration : IEntityTypeConfiguration<PlayerEntity>
{
    public void Configure(EntityTypeBuilder<PlayerEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Position)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<PlayerPosition>(v)
            );

        builder.Property(p => p.SpecificPosition)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<SpecificPosition>(v)
            );

        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(p => p.Participation)
            .IsRequired()
            .HasConversion<int>();

        builder.HasOne(p => p.ClubEntity)
          .WithMany(c => c.Players)
          .HasForeignKey(p => p.ClubId);
    }
}
