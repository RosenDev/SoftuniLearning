using System.Threading.Tasks;
using App.ViewModels;

namespace App.Services
{
    public interface IUserService
    {
        UserViewModel CreateUser(UserViewModel user);
     Task<UserViewModel> CreateUserAsync(UserViewModel user);
        UserViewModel GetUser(string username, string password);
    }
}