using MediChain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediChain.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Medicine", DisplayOrder = 1 },
                new Category { CategoryId = 2, CategoryName = "Medical Equipment", DisplayOrder = 2 },
                new Category { CategoryId = 3, CategoryName = "Miscellaneous", DisplayOrder = 3 }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Paracetamol", Description = "500MG,Painkiller", Price = 10, CategoryId = 1, ImageUrl=""},
                new Product { ProductId = 2, ProductName = "Surgical Mask", Description = "3 Ply, Pack of 50", Price = 50, CategoryId = 2, ImageUrl=""},
                new Product { ProductId = 3, ProductName = "Hand Sanitizer", Description = "500ML, 70% Alcohol", Price = 100, CategoryId = 3, ImageUrl = "" },
                new Product { ProductId = 4, ProductName = "Digital Thermometer", Description = "Infrared, Non-Contact", Price = 200, CategoryId = 2, ImageUrl = "" },
                new Product { ProductId = 5, ProductName = "Face Shield", Description = "Pack of 10", Price = 150, CategoryId = 2, ImageUrl = "" },
                new Product { ProductId = 6, ProductName = "Pulse Oximeter", Description = "Fingertip, Blood Oxygen Monitor", Price = 500, CategoryId = 2 , ImageUrl = "" }
            );
        }
    }
}
