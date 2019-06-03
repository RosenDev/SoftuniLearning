using SIS.HTTP.Enums;
using SIS.HTTP.Responce;

namespace SIS.WebServer.Results
{
    public abstract class ActionResult:HttpResponse
    {
        protected ActionResult(HttpResponseStatusCode code):base(code)
        {
            
        }
    }
}