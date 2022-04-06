using FoodTrackingApp.Data;
using FoodTrackingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTrackingApp.Repositories
{
    public class FoodRepositoryClass : IFood
    {
        private bool disposedValue;
        private ApplicationDbContext _context;
        

        public FoodRepositoryClass(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        public void DeleteFoodRecord(int id)
        {
            Food food = _context.FoodRecord.Find(id);
            _context.FoodRecord.Remove(food);
        }

        public IEnumerable<Food> GetAll()
        {
            return _context.FoodRecord.ToList();
        }
        public Food? GetByID(int id)
        {
            return _context.FoodRecord.Find(id);
        }

        public IEnumerable<Food> GetFoodRecordsByPhrase(string Phrase)
        {
            return _context.FoodRecord
                .Where(x => x.Carbohydrate.Contains(Phrase)
                || x.Protein.Contains(Phrase)
                || x.Fat.Contains(Phrase)
                || x.Snacks.Contains(Phrase)).ToList();
        }

        public IEnumerable<Food> GetFoodRecordsByDate(DateTime datefilter)
        {
            return _context.FoodRecord.Where(x => x.CreatedDate.Date == datefilter).ToList();
        }

        public void InsertFoodRecord(Food food)
        {
            _context.FoodRecord.Add(food);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateFoodRecord(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
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
                this.disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FoodRepositoryClass()
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
