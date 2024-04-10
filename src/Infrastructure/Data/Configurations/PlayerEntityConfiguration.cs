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

        builder.HasOne(p => p.ClubEntity)
          .WithMany(c => c.Players)
          .HasForeignKey(p => p.ClubId);
    }
}
