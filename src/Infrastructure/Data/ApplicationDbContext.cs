﻿using Domain.Entities;
using Domain.ValueObject;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Administrator> Administrators { get; set; }

    /*
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
         .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.Points)
            .HasConversion(
                v => v.Value,
                v => new Points(v)
            );

        modelBuilder.Entity<User>()
            .Property(u => u.UserName)
            .HasConversion(
               v => v.GetValue(),
            v => UserName.Create(v)
            );

        modelBuilder.Entity<User>()
        .Property(u => u.Email)
        .HasConversion(
            v => v.GetValue(),
            v => Email.Create(v)
        );

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
