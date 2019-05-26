using System;
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
           
            return View();
        }

        public IHttpResponse IndexLogged(IHttpRequest req)
        {
            var session = req.Session.GetParameter("username");
            using (var context= new AppDbContext())
            {
                
            }
            return View();
        }
    }
}