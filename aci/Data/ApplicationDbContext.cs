using Microsoft.EntityFrameworkCore;
using aci.Models;
using Microsoft.Extensions.FileSystemGlobbing;

namespace tutorial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operator>().HasData(
                new Operator { Id = 1, Name = "Carlos" },
                new Operator { Id = 2, Name = "Rafael" },
                new Operator { Id = 3, Name = "Viviana" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Gomitas", Reference = "001" },
                new Product { Id = 2, Name = "Frunas", Reference = "002" },
                new Product { Id = 3, Name = "Galletas", Reference = "003" },
                new Product { Id = 4, Name = "Sparkies", Reference = "004" },
                new Product { Id = 5, Name = "BomBom-Bum", Reference = "005" });

            modelBuilder.Entity<Order>()
            .Property(o => o.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Batch>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
