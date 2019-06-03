using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;

namespace SIS.WebServer.Results
{
    public class XmlResult:ActionResult
    {
        public XmlResult(string xmlContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok) : base(httpResponseStatusCode)
        {
            this.AddHeader(new HttpHeader(GlobalConstants.ContentType, "application/xml"));
            this.Content = Encoding.UTF8.GetBytes(xmlContent);
        }
    }
}