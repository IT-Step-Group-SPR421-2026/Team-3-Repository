using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data.Entities;

namespace Shop_mvc_pv421.Data
{
    public class ShopDbContext : IdentityDbContext<User>
    {
        public ShopDbContext() {
            //Database.EnsureCreated();
        }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopPv421;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //DbInitializer.SeedCategories(modelBuilder);
            //DbInitializer.SeedProducts(modelBuilder);

            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();

            // TODO: move to separate class
            modelBuilder.Entity<OrderDetails>().HasOne(x => x.Order).WithMany(x => x.Items).HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<OrderDetails>().HasOne(x => x.Product).WithMany(x => x.Orders).HasForeignKey(x => x.ProductId);
        }
    }
}
