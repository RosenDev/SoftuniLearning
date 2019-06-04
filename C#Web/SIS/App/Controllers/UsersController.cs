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
using SIS.WebServer.Extensions;
using SIS.WebServer.Results;
using  IServiceProvider=SIS.WebServer.DependecyContainer.IServiceProvider;

namespace App.Controllers
{
    public class UsersController:BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService service)
        {
            userService = service;
        }
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
                    if (Request.QueryData.ContainsKey("returnUrl"))
                    {
                        return Redirect((string)Request.QueryData["returnUrl"][0]);
                    }
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
        public ActionResult RegisterConfirm(string username, string password
            , string confirmPassword,string email)
        {
            if (password==confirmPassword)
            {
                var user = new UserViewModel
                {
                    Username = username,
                    Password = password,
                    Email = email
                };
                var result = userService.CreateUser(user);
                Console.WriteLine(result.Id + " " + result.Username);
                return Login();
            }
            

            return View();
        }
        
        public ActionResult Logout()
        {
            SignOut();
            return Redirect($"/Users/Login");
        }
        
    }
}