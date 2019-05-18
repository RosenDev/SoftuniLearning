using System;
using SIS.HTTP.Enums;
using SIS.HTTP.Request;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce.Interfaces;

namespace SIS.WebServer.Routing.Interfaces
{
    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod requestMethod,string path,Func<IHttpRequest,IHttpResponse>func);
        bool Contains(HttpRequestMethod method,string path);
        Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path);

    }
}