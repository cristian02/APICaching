using Microsoft.EntityFrameworkCore;
using APICaching.Models; 

namespace APICaching.Data;
public class AppDbContext : DbContext
{
    public DbSet<Student> Students{ get;set;}

    protected override void  OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>(entity=>
        {
            entity.Property(e=>e.Age).HasColumnType("int");
        });
    }

    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {

    }
}