using Application.Authentication;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class AdminEntityConfiguration : IEntityTypeConfiguration<AdminEntity>
{
    private readonly IPasswordHashService _passwordHashService;

    public AdminEntityConfiguration(IPasswordHashService passwordHashService)
    {
        _passwordHashService = passwordHashService;
    }

    public void Configure(EntityTypeBuilder<AdminEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasData(
            AdminEntity.Create
              (
                "ewerton",
                "Root",
                "ewerton@gmail.com",
                _passwordHashService.HashPassword("ewertonroot"),
                AdminLevel.RootAdmin,
                AdminLevel.RootAdmin
              )
            );

        builder.Property(a => a.Email)
            .HasConversion(
                v => v.Value,
                v => Email.Create(v)
            );

        builder.Property(a => a.Level)
            .HasConversion<int>();
    }
}
