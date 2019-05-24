using System.Text;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responce;

namespace SIS.WebServer.Results
{
    public class HtmlResult:HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode statusCode)
            :base(statusCode)
        {

            Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset-utf8"));
            Content = Encoding.UTF8.GetBytes(content);
        }
    }
}