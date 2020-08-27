using System;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Extensions;
using ShoppingOnline.Models;

namespace ShoppingOnline.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersItems> OrdersItems { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Profile)
                .WithOne(b => b.User)
                .HasForeignKey<Profile>(b => b.UserRef);

            modelBuilder.Entity<ProductPicture>()
                .HasOne<Product>(s => s.Product)
                .WithMany(p => p.ProductPictures)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductDetail)
                .WithOne(p => p.Product)
                .HasForeignKey<ProductDetail>(p => p.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Ratings)
                .HasForeignKey(r => r.ProductRef)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profile>()
                .HasOne(r => r.Rating)
                .WithOne(p => p.Profile)
                .HasForeignKey<Rating>(r => r.ProfileRef);
            
            modelBuilder.OrdersBuilder();
            
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Profile>().ToTable("Profile");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductPicture>().ToTable("ProductPicture");
            modelBuilder.Entity<ProductDetail>().ToTable("ProductDetail");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrdersItems>().ToTable("OrdersItems");
            
            modelBuilder.Seed();
        }
    }
}