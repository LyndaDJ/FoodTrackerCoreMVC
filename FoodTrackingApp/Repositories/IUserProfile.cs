using FoodTrackingApp.Models;

namespace FoodTrackingApp.Repositories
{
    public interface IUserProfile:IDisposable
    { 
        void CreateNewprofile(UserProfile userProfile);
        void EditProfile(UserProfile userProfile);
        UserProfile GetByID(int id);
        void Save();
    }
}
