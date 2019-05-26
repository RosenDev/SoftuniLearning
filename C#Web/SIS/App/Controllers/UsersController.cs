using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using App.Data;
using App.Models;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce.Interfaces;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class UsersController:BaseController
    {//GET
        public IHttpResponse Login(IHttpRequest request)
        {

            return View();
        }
        //post
        public IHttpResponse LoginConfirm(IHttpRequest req)
        {
            var username = (string)req.FormData["username"][0];
            var password = (string)req.FormData["password"][0];
            using (var context= new AppDbContext())
            {
                password = MD5(password);
                var user = context.Users.FirstOrDefault(x => x.Username == username && 
                                                             x.Password == password);
                if (user!=null)
                {
                    //TODO add redirect url after logging in
                    
                   req.Session.AddParameter("username",username);
                   return Redirect("/Home/Index-Logged");
                }
            }
            return Redirect("/Users/Login");
        }

        public IHttpResponse Register(IHttpRequest req)
        {
            return View();

        }

        public  IHttpResponse RegisterConfirm(IHttpRequest req)
        {
            var username = (string)req.FormData["username"][0];
            var password = (string)req.FormData["password"][0];
            var confirmPassword = (string)req.FormData["confirmPassword"][0];
            var email = (string)req.FormData["email"][0];
            if (password==confirmPassword)
            {
                using (var ctx= new AppDbContext())
                {
                    ctx.Users.Add(new User{Email = email,Username = username,Password = MD5(password)});
                    ctx.SaveChanges();
                    req.Session.AddParameter("username",username);
                    return Redirect("/Home/Index-Logged");
                }
                
            }
            return View();
        }

        private string MD5(string password)
        {
            MD5 hasher = new MD5CryptoServiceProvider();
            var bytes = Encoding.Unicode.GetBytes(password);
             hasher.ComputeHash(bytes);
             var hashedPassword = hasher.Hash;
             var sb= new StringBuilder();
             foreach (var b in bytes)
             {
                 sb.Append(b.ToString("x2"));
             }

             return sb.ToString().Trim();
        }
    }
}