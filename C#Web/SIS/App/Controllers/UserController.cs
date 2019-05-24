using System;
using System.Security.Cryptography;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce.Interfaces;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class UserController:BaseController
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
            Console.WriteLine(password);
            return Redirect("/");
        }
    }
}