using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;

namespace SIS.WebServer.Results
{
    public class FileResult : ActionResult
    {
        public FileResult(byte[] fileContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok) : base(httpResponseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(GlobalConstants.ContentLength, fileContent.Length.ToString()));
            this.Headers.AddHeader(new HttpHeader(GlobalConstants.ContentDisposition, "attachment"));
            this.Content = fileContent;
        }
    }
}