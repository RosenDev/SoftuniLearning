using System.Collections.Generic;
using PANDA.Data.Models;
namespace PANDA.Services
{
    public interface IUserService
    {
        User GetUserLogin(string username, string password);
        List<string> GetAllUsernames();
        bool CreateUser(User user);
    }
}