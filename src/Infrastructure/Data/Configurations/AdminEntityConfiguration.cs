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
                "ewerton_Root",
                "ewerton@gmail.com",
                _passwordHashService.HashPassword("ewertonroot"),
                UserRole.root
              )
            );

        builder.Property(a => a.Email)
            .HasConversion(
                v => v.Value,
                v => Email.Create(v)
            );

        builder.Property(a => a.Role)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<UserRole>(v)
            );
    }
}
