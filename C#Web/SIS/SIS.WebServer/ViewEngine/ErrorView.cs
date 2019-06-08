using SIS.WebServer.Identity;
using SIS.WebServer.Validation;

namespace SIS.WebServer.ViewEngine
{
    public class ErrorView:IView
    {
        private readonly string errors;
        public string GetHtml(object model,ModelStateDictionary modelState, Principal user)
        {
            return errors;
        }

        public ErrorView(string errors)
        {
            this.errors = errors;
        }
    }
}