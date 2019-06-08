using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using App.Services;
using App.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Login()
        {

            return View();
        }
        
        [HttpPost(action:"Login")]
        public IActionResult LoginConfirm(string username, string password)
        {
            var userViewModel= new UserViewModel
            {
                Username = username,
                Password = password
            };
           
            var user = userService.GetUser(userViewModel.Username, userViewModel.Password);
                if (user!=null)
                {
                    SignIn(user.Id.ToString(),user.Username,user.Email);
                    if (Request.QueryData.ContainsKey("returnUrl"))
                    {
                        return Redirect((string)Request.QueryData["returnUrl"][0]);
                    }
                   return Redirect("/Home/IndexLogged");
                }

            return Redirect("/Users/Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }

        [HttpPost(action:"Register")]
        public IActionResult RegisterConfirm(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (user.Password==user.ConfirmPassword)
            {
              
                var result = userService.CreateUser(user);
                return Redirect("/Users/Login");
            }
            

            return View();
        }
        
        public IActionResult Logout()
        {
            SignOut();
            return Redirect($"/Users/Login");
        }
        
    }
}