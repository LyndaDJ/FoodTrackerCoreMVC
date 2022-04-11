using FoodTrackingApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTrackingApp2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
