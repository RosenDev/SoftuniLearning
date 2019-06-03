using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responce;

namespace SIS.WebServer.Results
{
    public class InlineResourceResult:ActionResult
    {
        public InlineResourceResult(byte[] content,HttpResponseStatusCode statusCode)
            :base(statusCode)
        {
            Headers.AddHeader(new HttpHeader(GlobalConstants.ContentLength,content.Length.ToString()));
            Headers.AddHeader(new HttpHeader(GlobalConstants.ContentDisposition,"inline"));
            Content = content;
        }
    }
}