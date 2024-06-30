
using Microsoft.EntityFrameworkCore;
using Shopping_Project.Models;

namespace Shopping_Project.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Category> category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "C1", DisplayOrder = 1 },
                new Category { Id = 2, Name = "C2", DisplayOrder = 2 },
                new Category { Id = 3, Name = "C3", DisplayOrder = 3 });
        }
    }
}
