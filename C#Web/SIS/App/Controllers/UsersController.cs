using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using App.Services;
using App.ViewModels;
using SIS.WebServer;
using SIS.WebServer.Attributes;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class UsersController:BaseController
    {
        private readonly IUserService userService= new UserService();
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        
        [HttpPost(action:"Login")]
        public ActionResult LoginConfirm(string username, string password)
        {
           
            var user = userService.GetUser(username, password);
                if (user!=null)
                {
          
                    
                  SignIn(user.Id,username,user.Email);
                   return Redirect("/Home/IndexLogged");
                }
         

            
            return Redirect("/Users/Login");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost(action:"Register")]
        public ActionResult RegisterConfirm()
        {
            var username = (string)Request.FormData["username"][0];
            var password = (string)Request.FormData["password"][0];
            var confirmPassword = (string)Request.FormData["confirmPassword"][0];
            var email = (string)Request.FormData["email"][0];
            if (password==confirmPassword)
            {
                var user = new UserViewModel
                {
                    Username = username,
                    Password = password,
                    Email = email
                };
                var result = userService.CreateUser(user);//.GetAwaiter().GetResult();
                Console.WriteLine(result.Id + " " + result.Username);
                return Login();
            }
            

            return View();
        }
        
        public ActionResult Logout()
        {
            SignOut();
            return Redirect("/");
        }
        
    }
}