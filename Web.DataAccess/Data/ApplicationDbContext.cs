using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccesss.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<FoodType> FoodType { get; set; }

        public DbSet<MenuItem> MenuItem { get; set; }
    }
}
