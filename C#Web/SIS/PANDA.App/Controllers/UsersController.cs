using PANDA.App.BindingModels.User;
using PANDA.Data.Models;
using PANDA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace PANDA.App.Controllers
{
    public class UsersController:Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost(ActionName = "Register")]
        public IActionResult RegisterConfirm(UserRegisterInputBindingModel userRegisterCreate)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Users/Register");
            }

            var user = new User
            {
                Email = userRegisterCreate.Email,
                Username = userRegisterCreate.Username,
                Password = userRegisterCreate.Password
            };
            if (userService.CreateUser(user))
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(ActionName = "Login")]
        public IActionResult LoginConfirm(UserLoginInputBindingModel userLogin)
        {
            if (!ModelState.IsValid)
            {


                return Redirect("/Users/Login");
            }

            var user = userService.GetUserLogin(userLogin.Username,userLogin.Password);
            if (user!=null)
            {
             SignIn(user.Id.ToString(),user.Username,user.Email);
            
                return Redirect("/Home/IndexLoggedIn");
            }

            return Redirect("/Users/Login");
        }

        public IActionResult Logout()
        {
            SignOut();
            return Redirect("/Users/Login");
        }
    }
}