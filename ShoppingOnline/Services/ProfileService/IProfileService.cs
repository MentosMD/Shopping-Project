using ShoppingOnline.Models;

namespace ShoppingOnline.Services.ProfileService
{
    public interface IProfileService
    {
        void AddNewProfile(Profile newProfile);
        void UpdateProfile(Profile updatedProfile);
        Profile GetById(int id);
    }
}