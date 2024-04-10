using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ClubEntityConfiguration : IEntityTypeConfiguration<ClubEntity>
{
    public void Configure(EntityTypeBuilder<ClubEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired();

        builder.Property(c => c.Country)
            .IsRequired();

        builder.Property(c => c.Trainer)
            .IsRequired();
    }
}
