using System.Text;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;

namespace SIS.WebServer.Results
{
    public class ForbiddenResult:ActionResult
    {
        public ForbiddenResult(string msg,HttpResponseStatusCode code=HttpResponseStatusCode.Forbidden) : base(code)
        {
            Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset-utf8"));
            Content = Encoding.UTF8.GetBytes(msg);
        }
    }
}