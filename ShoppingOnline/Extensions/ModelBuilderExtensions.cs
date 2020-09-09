using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models;

namespace ShoppingOnline.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { ID = 1, Name = "Xiaomi Redmi 8A", Price = 2099, Discount = 100, CodeProduct = "00-00044898-002" },
                new Product() { ID = 2, Name = "Apple iPhone XS", Price = 14499, Discount = 2000, CodeProduct = "00-00036714-012" },
                new Product() { ID = 3, Name = "Samsung Galaxy A71 A715", Price = 8299, Discount = 200, CodeProduct = "00-00045830-003" },
                new Product() { ID = 4, Name = "Samsung Galaxy M30s M307", Price = 4999, Discount = 0, CodeProduct = "00-00044893-001" },
                new Product() { ID = 5, Name = "Asus Zenfone 6 ZE630KL", Price = 9999, Discount = 3500, CodeProduct = "00-00044504-001" },
                new Product() { ID = 6, Name = "Sony Xperia 1 J9110", Price = 15499, Discount = 1500, CodeProduct = "00-00044328-002" },
                new Product() { ID = 7, Name = "Nokia 5.1", Price = 1999, Discount = 100, CodeProduct = "00-00036476-003" }
            );
        }

        public static void OrdersBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasMany(o => o.Orders)
                .WithOne(o => o.Profile)
                .HasForeignKey(p => p.ProfileRef)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrdersItems>()
                .HasOne(o => o.Order)
                .WithMany(o => o.OrdersItems)
                .HasForeignKey(o => o.OrderRef)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(o => o.OrderItems)
                .WithOne(p => p.Product)
                .HasForeignKey<OrdersItems>(p => p.ProductRef);
        }
    }
}