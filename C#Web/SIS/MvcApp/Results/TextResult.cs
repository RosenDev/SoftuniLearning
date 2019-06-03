using System.Text;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responce;

namespace SIS.WebServer.Results
{
    public class TextResult:ActionResult
    {
        public TextResult(string content,HttpResponseStatusCode statusCode,string type="text/plain; charset-utf8")
            :base(statusCode)
        {
            Headers.AddHeader(new HttpHeader("Content-Type", type));
            Content = Encoding.UTF8.GetBytes(content);

        }

        public TextResult(byte[] content,HttpResponseStatusCode statusCode,string contentType= "text/plain; charset-utf8")
        :base(statusCode)
        {
            Content = content;
            Headers.AddHeader(new HttpHeader("Content-Type",contentType));
        }
    }
}