using FoodTrackerCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTrackerCoreMVC.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }
    }
}
