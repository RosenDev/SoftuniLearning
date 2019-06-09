using SIS.WebServer.Identity;
using SIS.WebServer.Validation;

namespace SIS.WebServer.ViewEngine
{
    /// <summary>
    /// The base interface for any View.
    /// </summary>
    public interface IView
    {
        string GetHtml(object model,ModelStateDictionary modelState,Principal user);
    }
}