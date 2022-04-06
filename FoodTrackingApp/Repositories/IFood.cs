using FoodTrackingApp.Models;

namespace FoodTrackingApp.Repositories
{
    public interface IFood : IDisposable
    {
        IEnumerable<Food> GetAll();
        void InsertFoodRecord(Food food);
        void DeleteFoodRecord(int id);
        void UpdateFoodRecord(Food food);
        Food GetByID(int id);
        IEnumerable<Food> GetFoodRecordsByPhrase(string Phrase);
        IEnumerable<Food> GetFoodRecordsByDate(DateTime datefilter);
        void Save();

    }
}
