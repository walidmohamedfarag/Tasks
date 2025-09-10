using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;

namespace P02_SalesDatabase.Data
{
    internal class ApplicationDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;Initial Catalog=EFTask1;Encrypt=True;" +
                "Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .HasMaxLength(50)
                .IsUnicode(true);
            modelBuilder.Entity<Customer>() 
                .HasKey(c => c.CustomerId);
            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(true);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            modelBuilder.Entity<Store>()
                .HasKey(s => s.StoreId);
            modelBuilder.Entity<Store>()
                .Property(s => s.StoreName)
                .HasMaxLength(80)
                .IsUnicode(true);
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

        }
    }
}
