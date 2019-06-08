using SIS.HTTP.Enums;
using SIS.HTTP.Responce;

namespace SIS.WebServer.Results
{
    public abstract class ActionResult:HttpResponse,IActionResult
    {
        protected ActionResult(HttpResponseStatusCode code):base(code)
        {
            
        }
    }
}