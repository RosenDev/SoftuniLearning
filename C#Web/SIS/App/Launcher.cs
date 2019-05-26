using System;
using System.Collections.Generic;
using App.Controllers;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SIS.HTTP.Enums;
using SIS.HTTP.Request;
using SIS.HTTP.Request.Interfaces;
using SIS.WebServer;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;
using SIS.WebServer.Routing.Interfaces;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
           IServerRoutingTable table = new ServerRoutingTable();

            #region Home

            table.Add(HttpRequestMethod.Get, "/", req => new RedirectResult("/Home/Index"));
            table.Add(HttpRequestMethod.Get,"/Home/Index",req=>new HomeController().Index(req));
            table.Add(HttpRequestMethod.Get,"/Home/Index-Logged",req=>new HomeController().IndexLogged(req));


            #endregion
            #region Users

            table.Add(HttpRequestMethod.Get, "/Users/Login", req => new UsersController().Login(req));
            table.Add(HttpRequestMethod.Post, "/Users/Login", req => new UsersController().LoginConfirm(req));
            table.Add(HttpRequestMethod.Get,"/Users/Register",req=>new UsersController().Register(req));
            table.Add(HttpRequestMethod.Post,"/Users/Register",req=>new UsersController().RegisterConfirm(req));
            #endregion
            #region Albums
            table.Add(HttpRequestMethod.Get, "/Albums/All", req => new AlbumsController().All(req));
            table.Add(HttpRequestMethod.Get,"/Albums/Details",req=>new AlbumsController().Details(req));
            table.Add(HttpRequestMethod.Get,"/Albums/Create",req=>new AlbumsController().Create(req));
            table.Add(HttpRequestMethod.Post,"/Albums/Create",req=>new AlbumsController().CreateConfirm(req));
            #endregion

           

            var server = new Server(8000, table);
            
           server.Start();
        }
    }
}
