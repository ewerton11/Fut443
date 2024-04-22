using Domain.Aggregates;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObject;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {

        builder.HasKey(u => u.Id);

        /*
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.Points)
            .HasConversion(
                v => v.Value,
                v => new Points(v)
            );
        */

        builder.Property(u => u.FirstName)
            .HasConversion(
             v => v.Value,
             v => FirstName.Create(v)
            );

        builder.Property(u => u.LastName)
            .HasConversion(
             v => v.Value,
             v => LastName.Create(v)
            );

        builder.Property(u => u.Birthday)
            .HasConversion(
             v => v.Value,
             v => BirthDate.Create(v)
            );

        builder.Property(u => u.UserName)
            .HasConversion(
             v => v.Value,
             v => UserName.Create(v)
            );

        builder.Property(u => u.Email)
            .HasConversion(
                v => v.Value,
                v => Email.Create(v)
            );
    }
}
