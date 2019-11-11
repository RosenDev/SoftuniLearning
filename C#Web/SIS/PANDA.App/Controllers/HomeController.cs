using System;
using System.Globalization;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace PANDA.App.Controllers
{
    public class HomeController:Controller
    {

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            if (Request.Session.ContainsParameter("principal"))
            {
                return IndexLoggedIn();
            }

            
            return Index();
        }
        public IActionResult Index()
        {
            return View();
        }

        
        [Authorize]
        public IActionResult IndexLoggedIn()
        {
            return View(User);
        }
    }
}