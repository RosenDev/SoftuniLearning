using SIS.HTTP.Enums;

namespace SIS.WebServer.Attributes
{
   
    public class HttpGetAttribute:BaseHttpAttribute
    {
        public override string Name { get; }
        public override HttpRequestMethod RequestMethod { get; } = HttpRequestMethod.Get;
        public override string Path { get; }
        public override string Action { get; }

        public HttpGetAttribute(string name=null, string path=null, string action=null)
        {
            Name = name;
            Path = path;
            Action = action;
        }
    }
}
