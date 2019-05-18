using System;
using System.Collections.Generic;
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
           table.Add(HttpRequestMethod.Get,"/",req=>new HomeController().Index(req));
           var server = new Server(8000, table);
           server.Start();
        }
    }
}
