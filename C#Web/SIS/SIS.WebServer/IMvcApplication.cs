using SIS.WebServer.Routing;

namespace SIS.WebServer
{
    public interface IMvcApplication
    {
        void Configure(IServerRoutingTable table);
        void ConfigureServices();
    }
}