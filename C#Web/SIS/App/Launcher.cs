using System;
using System.Collections.Generic;
using App.Controllers;
using SIS.HTTP.Enums;
using SIS.HTTP.Request;
using SIS.WebServer;
using SIS.WebServer.Routing;
using SIS.WebServer.Routing.Interfaces;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
           IServerRoutingTable table = new ServerRoutingTable();
           table.Add(HttpRequestMethod.Get,"/",req=>new HomeController().Home(req));
           table.Add(HttpRequestMethod.Get,"/login",req=>new UserController().Login(req));
           table.Add(HttpRequestMethod.Post,"/login",req=>new UserController().LoginConfirm(req));
           var server = new Server(8000, table);
           server.Start();
        }
    }
}
