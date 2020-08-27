using ShoppingOnline.Models;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Services
{
    public interface IUserService
    {
        object Authenticate(LoginViewModel model);
        User GetById(int id);
        void AddNewUser(User newUser);
        void ChangePassword(User user);
    }
}