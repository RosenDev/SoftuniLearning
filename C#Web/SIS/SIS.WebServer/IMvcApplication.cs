using SIS.WebServer.DependecyContainer;
using SIS.WebServer.Routing;

namespace SIS.WebServer
{
    public interface IMvcApplication
    {
        void Configure(IServerRoutingTable table);
        IServiceProvider ConfigureServices();
    }
}