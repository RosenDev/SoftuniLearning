using System.Collections.Generic;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Sessions;

namespace SIS.HTTP.Request
{
    public interface IHttpRequest
    {
        string Path { get;}
        string Url { get;}
        Dictionary<string,List<object>> FormData { get;}
        Dictionary<string,List<object>> QueryData { get;}
        IHttpSession Session { get; set; }
        IHttpHeaderCollection Headers { get;}
        IHttpCookieCollection Cookies { get; }
        HttpRequestMethod RequestMethod { get; }
    }
}