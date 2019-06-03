using SIS.WebServer.Identity;

namespace SIS.WebServer.ViewEngine
{
    public interface IView
    {
        string GetHtml(object model,Principal user);
    }
}