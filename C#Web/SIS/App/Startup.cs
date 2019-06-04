using App.Controllers;
using App.Services;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.DependecyContainer;
using SIS.WebServer.Routing;

namespace App
{
    public class Startup:IMvcApplication
    {

        public void Configure(IServerRoutingTable table)
        {
        }

  

        public IServiceProvider ConfigureServices()
        {
           var provider= new ServiceProvider();
           provider.Add<IUserService,UserService>();
           provider.Add<IAlbumService, AlbumService>();
           provider.Add<ITrackService,TrackService>();
           return provider;
        }
       
    }

    
}