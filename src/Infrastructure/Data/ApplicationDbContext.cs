using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Administrator> Administrators { get; set; }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapeamento da classe User
        modelBuilder.Entity<User>(entity =>
        {
            // Chave primária
            entity.HasKey(e => e.Id);

            // Configurações adicionais, se houver
            // Exemplo: Para configurar o nome da tabela
            entity.ToTable("Users");
        });

        // Outros mapeamentos de entidades, se houver

        base.OnModelCreating(modelBuilder);
    }
    */
}
