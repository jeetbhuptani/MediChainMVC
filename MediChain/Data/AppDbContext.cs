using MediChain.Models;
using Microsoft.EntityFrameworkCore;

namespace MediChain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Medicine", DisplayOrder = 1 },
                new Category { CategoryId = 2, CategoryName = "Medical Equipment", DisplayOrder = 2 },
                new Category { CategoryId = 3, CategoryName = "Miscellaneous", DisplayOrder = 3 }
                );
        }
    }
}
