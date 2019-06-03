using SIS.HTTP.Enums;

namespace SIS.WebServer.Attributes
{
    public class HttpPutAttribute:BaseHttpAttribute
    {
        public HttpPutAttribute(string action=null, string path=null)
        {
            
            Action = action;
            Path = path;
        }

        public override string Name { get; } = "HttpPut";
        public override string Action { get; }
        public override string Path { get; }
        public override HttpRequestMethod RequestMethod { get; } = HttpRequestMethod.Put;
    }
}