using SIS.WebServer.Identity;

namespace SIS.WebServer.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml<T>(string viewContent, T model, Principal user);
    }
}