using System.Collections.Generic;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers.Interfaces;

namespace SIS.HTTP.Request.Interfaces
{
    public interface IHttpRequest
    {
        string Path { get;}
        string Url { get;}
        Dictionary<string,List<object>> FormData { get;}
        Dictionary<string,List<object>> QueryData { get;}
        IHttpHeaderCollection Headers { get;}
        HttpRequestMethod RequestMethod { get; }
    }
}