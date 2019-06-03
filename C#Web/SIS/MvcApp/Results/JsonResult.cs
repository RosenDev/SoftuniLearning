using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;

namespace SIS.WebServer.Results
{
    public class JsonResult:ActionResult
    {
        public JsonResult(string jsonContent, HttpResponseStatusCode code=HttpResponseStatusCode.Ok) : base(code)
        {
            this.AddHeader(new HttpHeader(GlobalConstants.ContentType, "application/json"));
            this.Content = Encoding.UTF8.GetBytes(jsonContent);
        }
    }
}