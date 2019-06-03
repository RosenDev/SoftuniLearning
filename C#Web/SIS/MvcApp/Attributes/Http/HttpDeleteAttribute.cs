using SIS.HTTP.Enums;

namespace SIS.WebServer.Attributes
{
    public class HttpDeleteAttribute:BaseHttpAttribute
    {
        public HttpDeleteAttribute(string path = null, string action = null)
        {
            Path = path;
            Action = action;
        }
        public override HttpRequestMethod RequestMethod { get; } = HttpRequestMethod.Delete;
        public override string Path { get; }
        public override string Name { get; } = "HttpDelete";
        public override string Action { get; }
    }
}