﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using App.Data;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Responce;
using SIS.WebServer;
using SIS.WebServer.Attributes;
using SIS.WebServer.Identity;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public class HomeController:Controller
    {
        public HomeController()
        {
            
        }
        [HttpGet(path:"/")]

        public IActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        [Authorized]
        public IActionResult IndexLogged()
        {
           
            var username = ((Principal)Request.Session.GetParameter("principal")).Username;
            using (var context= new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(x=>x.Username==username);
                
                return View(user);
            }
        }
    }
}