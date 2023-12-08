using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;

namespace MyWebApi.Data;

public class SqliteDbContext : DbContext
{
    //aqui nos quedamos
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Carrera> Carreras { get; set; }
     public DbSet<Docentes> Docentes { get; set; }
     public DbSet<Creditos> CreditosAlumnos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data/sit.db");
        base.OnConfiguring(optionsBuilder);        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Alumno>();
        
    }

    public SqliteDbContext(DbContextOptions options) : base(options)
    {
    }

}