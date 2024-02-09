using Domain.Aggregates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<AdminEntity> Admin { get; set; }

    public DbSet<PlayerEntity> Player { get; set; }

    public DbSet<Team> Team { get; set; }

    public DbSet<Championship> Championship { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
