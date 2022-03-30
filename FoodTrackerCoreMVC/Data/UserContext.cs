using FoodTrackerCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTrackerCoreMVC.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LAPTOP-P9THCP54; Database = FoodTrackerAccounts; TrustedConnection = True;");
        }
    }
}
