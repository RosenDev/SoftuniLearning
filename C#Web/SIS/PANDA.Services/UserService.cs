using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PANDA.Data;
using PANDA.Data.Models;

namespace PANDA.Services
{
    public class UserService:IUserService
    {
        private readonly PandaDbContext context;

        public UserService(PandaDbContext context)
        {
            this.context = context;
        }

        public User GetUserLogin(string username,string password)
        {
            using (context)
            {

                var user = context.Users
                    .SingleOrDefault(u => u.Username == username&&u.Password==MD5(password));
                return user;

            }
        }

        public List<string> GetAllUsernames()
        {
            using (context)
            {
                return context.Users.Select(x => x.Username).ToList();
            }
        }

        public bool CreateUser(User user)
        {

            using (context)
            {
                user.Password = MD5(user.Password);
                context.Users.Add(user);
                context.SaveChanges();
                    return true;
            }
        }
        private string MD5(string text)
        {
            var sb = new StringBuilder();
            var hasher = new MD5CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes(text);
            var hashedBytes = hasher.ComputeHash(bytes);
            hashedBytes.ToList()
                .ForEach(b => sb.AppendLine(b.ToString("x2")));
            return sb.ToString();
        }
    }

}