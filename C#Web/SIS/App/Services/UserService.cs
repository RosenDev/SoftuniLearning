using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using App.ViewModels;
using Microsoft.EntityFrameworkCore;
using SIS.MvcFramework.Mapping;

namespace App.Services
{
    public class UserService:IUserService
    {
        public UserViewModel CreateUser(UserViewModel user)
        {
            using (var ctx = new AppDbContext())
            {
                var userForDb = new User
                {
                    Email = user.Email,
                    Username = user.Username,
                    Password = MD5(user.Password)
                };
                ctx.Users.Add(userForDb);
                 ctx.SaveChanges();
                 return userForDb.To<UserViewModel>();
            }
        }
        public async Task<UserViewModel> CreateUserAsync(UserViewModel user)
        {

            using (var ctx = new AppDbContext())
            {
                var userForDb = new User
                {
                    Email = user.Email,
                    Username = user.Username,
                    Password = MD5(user.Password)
                };
                ctx.Users.Add(userForDb);
                await ctx.SaveChangesAsync();
                return new UserViewModel
                {
                    Username = userForDb.Username,
                    Password = userForDb.Password,
                    Email = userForDb.Email,
                    Id = userForDb.Id.ToString()

                };


            }

        }

        public UserViewModel GetUser(string username, string password)
        {
            using (var context = new AppDbContext())
            {
                password = MD5(password);
                var user = context
                    .Users
                    .SingleOrDefault(x => x.Username == username && x.Password == password);
                
                return user.To<UserViewModel>();
            }
        }
        private string MD5(string password)
        {
            MD5 hasher = new MD5CryptoServiceProvider();
            var bytes = Encoding.Unicode.GetBytes(password);
            hasher.ComputeHash(bytes);
            var hashedPassword = hasher.Hash;
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString().Trim();
        }
    }

}
