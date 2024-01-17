using Domain.Entities;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; }
    // public DbSet<Administrator> Administrators { get; set; }

    /*
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        /*
        modelBuilder.Entity<Administrator>()
         .HasKey(a => a.Id);

        modelBuilder.Entity<Administrator>()
            .Property(a => a.UserName)
            .HasConversion(
               v => v.GetValue(),
            v => UserName.Create(v)
            );

        modelBuilder.Entity<Administrator>()
        .Property(a => a.Email)
        .HasConversion(
            v => v.GetValue(),
            v => Email.Create(v)
        );
        */
    }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.OwnsOne(u => u.Points, points =>
            {
                points.Property(p => p.Value).HasColumnName("Points");
            });
        });
    }
    */

}
