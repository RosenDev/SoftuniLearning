using SIS.HTTP.Enums;

namespace SIS.WebServer.Attributes
{
    public class HttpPostAttribute:BaseHttpAttribute
    {
        public HttpPostAttribute(string path=null, string action=null)
        {
            Path = path;
            Action = action;
        }
        public override HttpRequestMethod RequestMethod { get; } = HttpRequestMethod.Post;
        public override string Path { get; }
        public override string Name { get; } = "HttpPost";
        public override string Action { get; }
    }
}
