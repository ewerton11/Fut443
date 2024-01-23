using Domain.Aggregates;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObject;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<AdminEntity> Administrators { get; set; }

    public DbSet<PlayerEntity> Player { get; set; }

    public DbSet<Team> Team { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações para a entidade AdministratorEntity

        modelBuilder.Entity<AdminEntity>()
         .HasKey(a => a.Id);

        modelBuilder.Entity<AdminEntity>()
         .HasData(
             AdminEntity.Create("ewerton_Root", "ewerton@gmal.com", "ewertonroot", UserRole.root)
         );

        modelBuilder.Entity<AdminEntity>()
        .Property(a => a.Email)
        .HasConversion(
            v => v.Value,
            v => Email.Create(v)
        );

        modelBuilder.Entity<AdminEntity>()
        .Property(a => a.Password)
        .HasConversion(
            v => v.Value,
            v => Password.Create(v)
        );

        modelBuilder.Entity<AdminEntity>()
        .Property(a => a.Role)
        .HasConversion(
            v => v.ToString(),
            v => Enum.Parse<UserRole>(v)
        );

        // Configurações para a entidade UserEntity

        modelBuilder.Entity<UserEntity>()
         .HasKey(u => u.Id);

        modelBuilder.Entity<UserEntity>()
            .Property(u => u.Points)
            .HasConversion(
                v => v.Value,
                v => new Points(v)
            );

        modelBuilder.Entity<UserEntity>()
            .Property(u => u.UserName)
            .HasConversion(
               v => v.Value,
               v => UserName.Create(v)
            );

        modelBuilder.Entity<UserEntity>()
        .Property(u => u.Email)
        .HasConversion(
            v => v.Value,
            v => Email.Create(v)
        );

        modelBuilder.Entity<UserEntity>()
        .Property(u => u.Password)
        .HasConversion(
            v => v.Value,
            v => Password.Create(v)
        );

        modelBuilder.Entity<UserEntity>()
        .Property(u => u.Role)
        .HasConversion(
            v => v.ToString(),
            v => Enum.Parse<UserRole>(v)
        );

        // Configurações para a entidade PlayerEntity

        modelBuilder.Entity<PlayerEntity>()
         .HasKey(p => p.Id);

        modelBuilder.Entity<PlayerEntity>()
        .Property(p => p.Position)
        .HasConversion(
            v => v.ToString(),
            v => Enum.Parse<PlayerPosition>(v)
        );

        // Configurações para a entidade Team

        modelBuilder.Entity<Team>()
         .HasKey(p => p.Id);

        modelBuilder.Entity<Team>()
       .Property(t => t.Name)
       .HasConversion(
           v => v.Value,
           v => TeamName.Create(v)
       );

        modelBuilder.Entity<Team>()
        .HasMany(t => t.Players)
        .WithOne()
        .HasForeignKey("TeamId")
        .OnDelete(DeleteBehavior.Cascade);
    }
}
