using FoodTrackingApp2.Data;
using FoodTrackingApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTrackingApp2.Repositories
{
    public class ProfileRepositoryClass : IProfileRepository
    {
        private bool disposedValue;
        private ApplicationDbContext _context;

        public ProfileRepositoryClass(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        public void CreateNewprofile(Profile profile)
        {
            _context.Profiles.Add(profile);
        }

        public void EditProfile(Profile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
        }

        /*public Profile GetByUsername(string username)
        {
            return _context.Profiles.Find(username);
        }*/
        public Profile GetByID(int id)
        {
            return _context.Profiles.Find(id);
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
