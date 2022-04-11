using FoodTrackingApp2.Models;

namespace FoodTrackingApp2.Repositories
{
    public interface IProfileRepository :IDisposable
    {
        void CreateNewprofile(Profile profile);
        void EditProfile(Profile profile);
        //Profile GetByUsername(string username);
        Profile GetByID(int id);
        void Save();
    }
}
