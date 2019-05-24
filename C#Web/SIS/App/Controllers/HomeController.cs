using System;
using System.Runtime.InteropServices;
using SIS.HTTP.Enums;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce;
using SIS.HTTP.Responce.Interfaces;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class HomeController:BaseController
    {
        public IHttpResponse Home(IHttpRequest httpRequest)
        {

            return View();
        }
    }
}