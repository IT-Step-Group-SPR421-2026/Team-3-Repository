using Microsoft.EntityFrameworkCore;
using Shop_mvc_pv421.Data.Entities;

namespace Shop_mvc_pv421.Data
{
    public static class DbInitializer
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {
                new() { Id = 1, Name = "Electronics" },
                new() { Id = 2, Name = "Sport" },
                new() { Id = 3, Name = "Fashion" },
                new() { Id = 4, Name = "Home & Garden" },
                new() { Id = 5, Name = "Transport" },
                new() { Id = 6, Name = "Toys & Hobbies" },
                new() { Id = 7, Name = "Musical Instruments" },
                new() { Id = 8, Name = "Art" },
                new() { Id = 9, Name = "Other" }
            });
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new() { Id = 1, Title = "iPhone X", CategoryId = 1, Discount = 10, Price = 650, Quantity = 5, ImageUrl = "https://applecity.com.ua/image/cache/catalog/0iphone/ipohnex/iphone-x-black-1000x1000.png" },
                new() { Id = 2, Title = "PowerBall", CategoryId = 2, Price = 45.5M, Quantity = 3, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_727192-CBT53879999753_022023-V.jpg" },
                new() { Id = 3, Title = "Nike T-Shirt", CategoryId = 3, Discount = 15, Price = 189, Quantity = 3, ImageUrl = "https://www.seekpng.com/png/detail/316-3168852_nike-air-logo-t-shirt-nike-t-shirt.png" },
                new() { Id = 4, Title = "Samsung S23", CategoryId = 1, Discount = 5, Price = 1200, Quantity = 0, ImageUrl = "https://sota.kh.ua/image/cache/data/Samsung-2/samsung-s23-s23plus-blk-01-700x700.webp" },
                new() { Id = 5, Title = "Air Ball", CategoryId = 6, Price = 50, Quantity = 0, ImageUrl = "https://cdn.shopify.com/s/files/1/0046/1163/7320/products/69ee701e-e806-4c4d-b804-d53dc1f0e11a_grande.jpg" },
                new() { Id = 6, Title = "MacBook Pro 2019", CategoryId = 1, Discount = 10, Quantity = 23, ImageUrl = "https://newtime.ua/image/import/catalog/mac/macbook_pro/MacBook-Pro-16-2019/MacBook-Pro-16-Space-Gray-2019/MacBook-Pro-16-Space-Gray-00.webp" },
                new() { Id = 7, Title = "Samsung S4", CategoryId = 2, Discount = 0, Price = 440, Quantity = 0 },
            });
        }
    }
}
