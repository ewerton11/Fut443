using Application.Authentication;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObject;
using Domain.ValueObjects;
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
                FirstName.Create("ewerton"),
                LastName.Create("Root"),
                Email.Create("ewerton@gmail.com"),
                _passwordHashService.HashPassword("ewertonroot"),
                AdminLevel.RootAdmin,
                AdminLevel.RootAdmin
              )
            );

        builder.Property(a => a.FirstName)
            .HasConversion(
             v => v.Value,
             v => FirstName.Create(v)
            );

        builder.Property(a => a.LastName)
            .HasConversion(
             v => v.Value,
             v => LastName.Create(v)
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
