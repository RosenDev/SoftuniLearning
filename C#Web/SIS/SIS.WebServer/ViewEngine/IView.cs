using SIS.WebServer.Identity;
using SIS.WebServer.Validation;

namespace SIS.WebServer.ViewEngine
{
    public interface IView
    {
        string GetHtml(object model,ModelStateDictionary modelState,Principal user);
    }
}