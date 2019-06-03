using App.Controllers;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;

namespace App
{
    public class Startup:IMvcApplication
    {

        public void Configure(IServerRoutingTable table)
        {
          /*  #region Home
            table.Add(HttpRequestMethod.Get, "/", req => new RedirectResult("/Home/Index"));
            table.Add(HttpRequestMethod.Get, "/Home/Index", req => new HomeController().Index(req));
            table.Add(HttpRequestMethod.Get, "/Home/Index-Logged", req => new HomeController().IndexLogged(req));
            #endregion

            #region Users
            table.Add(HttpRequestMethod.Get, "/Users/Login", req => new UsersController().Login(req));
            table.Add(HttpRequestMethod.Post, "/Users/Login", req => new UsersController().LoginConfirm(req));
            table.Add(HttpRequestMethod.Get, "/Users/Register", req => new UsersController().Register(req));
            table.Add(HttpRequestMethod.Post, "/Users/Register", req => new UsersController().RegisterConfirm(req));
            #endregion

            #region Albums
            table.Add(HttpRequestMethod.Get, "/Albums/All", req => new AlbumsController().All(req));
            table.Add(HttpRequestMethod.Get, "/Albums/Details", req => new AlbumsController().Details(req));
            table.Add(HttpRequestMethod.Get, "/Albums/Create", req => new AlbumsController().Create(req));
            table.Add(HttpRequestMethod.Post, "/Albums/Create", req => new AlbumsController().CreateConfirm(req));
            #endregion          
            */ 

        }

  

        public void ConfigureServices()
        {
           
        }
       
    }

    
}