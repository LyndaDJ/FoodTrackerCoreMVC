using FoodTrackingApp2.Data;
using FoodTrackingApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTrackingApp2.Repositories
{
    public class FoodRepositoryClass :IFoodRepository
    {
        private bool disposedValue;
        private ApplicationDbContext _context;


        public FoodRepositoryClass(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        public void DeleteFoodRecord(int id)
        {
            Food food = _context.Foods.Find(id);
            _context.Foods.Remove(food);
        }

        public IEnumerable<Food> GetAll()
        {
            return _context.Foods.ToList();
        }
        public Food? GetByID(int id)
        {
            return _context.Foods.Find(id);
        }

        public IEnumerable<Food> GetFoodRecordsByPhrase(string Phrase)
        {
            return _context.Foods
                .Where(x => x.Carbohydrate.Contains(Phrase)
                || x.Protein.Contains(Phrase)
                || x.Fat.Contains(Phrase)
                || x.Snacks.Contains(Phrase)).ToList();
        }

        public IEnumerable<Food> GetFoodRecordsByDate(DateTime datefilter)
        {
            return _context.Foods.Where(x => x.CreatedDate.Date == datefilter).ToList();
        }

        public void InsertFoodRecord(Food food)
        {
            _context.Foods.Add(food);
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
