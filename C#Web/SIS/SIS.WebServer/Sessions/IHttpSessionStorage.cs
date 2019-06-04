using SIS.HTTP.Sessions;

namespace SIS.WebServer
{
    public interface IHttpSessionStorage
    {
        IHttpSession GetSession(string id);

        bool ContainsSession(string sessionId);
    }
}