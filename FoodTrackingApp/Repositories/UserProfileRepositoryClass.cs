using FoodTrackingApp.Data;
using FoodTrackingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTrackingApp.Repositories
{
    public class UserProfileRepositoryClass : IUserProfile
    {
        private bool disposedValue;
        private ApplicationDbContext _context;

        public UserProfileRepositoryClass(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        public void CreateNewprofile(UserProfile userProfile)
        {
            _context.UserProfile.Add(userProfile);
        }

        public void EditProfile(UserProfile userProfile)
        {
            _context.Entry(userProfile).State = EntityState.Modified;
        }

        public UserProfile GetByID(int id)
        {
            return _context.UserProfile.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserProfileRepositoryClass()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
