using System.Threading.Tasks;
using App.Models;
using App.ViewModels;

namespace App.Services
{
    public interface IUserService
    {
        UserViewModel CreateUser(UserViewModel user);
     Task<UserViewModel> CreateUserAsync(UserViewModel user);
        User GetUser(string username, string password);
    }
}