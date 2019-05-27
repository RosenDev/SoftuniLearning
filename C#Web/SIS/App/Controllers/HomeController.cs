using System;
using System.Linq;
using System.Runtime.InteropServices;
using App.Data;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce;
using SIS.HTTP.Responce.Interfaces;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class HomeController:BaseController
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            if (IsLoggedIn(httpRequest))
            {
                return Redirect("/Home/IndexLogged");
            }
            return View();
        }

        public IHttpResponse IndexLogged(IHttpRequest req)
        {
            if (!IsLoggedIn(req))
            {
                return Redirect("/Users/Login");
            }
            var username = (string)req.Session.GetParameter("username");
            using (var context= new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(x=>x.Username==username);
                ViewData["Username"] = username;
            }
            return View();
        }
    }
}