using Application.Authentication;
using Domain.Aggregates;
using Domain.Entities;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    private readonly IPasswordHashService _passwordHashService;

    public DataContext(DbContextOptions<DataContext> options, IPasswordHashService passwordHashService) : base(options)
    {
        _passwordHashService = passwordHashService;
    }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<AdminEntity> Admin { get; set; }

    public DbSet<PlayerEntity> Player { get; set; }

    public DbSet<Team> Team { get; set; }

    public DbSet<Championship> Championship { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AdminEntityConfiguration(_passwordHashService));
        modelBuilder.ApplyConfiguration(new TeamEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ChampionshipEntityConfiguration());
    }
}
