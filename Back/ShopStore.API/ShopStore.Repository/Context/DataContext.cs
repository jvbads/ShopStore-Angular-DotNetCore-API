using Microsoft.EntityFrameworkCore;
using ShopStore.Domain.Entities;

namespace ShopStore.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //            .HasOne(a => a.Category).WithOne(b => b.Product)
            //            .HasForeignKey<Category>(b => b.ProductId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
