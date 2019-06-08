using SIS.WebServer.Identity;
using SIS.WebServer.Validation;

namespace SIS.WebServer.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml<T>(string viewContent, T model,ModelStateDictionary modelState, Principal user);
    }
}