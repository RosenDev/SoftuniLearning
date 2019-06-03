using System;
using System.Collections.Generic;
using SIS.HTTP.Enums;
using SIS.HTTP.Request;
using SIS.HTTP.Responce;

namespace SIS.WebServer.Routing
{
    public class ServerRoutingTable:IServerRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod,Dictionary<string,Func<IHttpRequest,IHttpResponse>>>routes;
        public ServerRoutingTable()
        {
            routes = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>()
            {
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post]= new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put]= new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete]= new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }
        public void Add(HttpRequestMethod requestMethod, string path, Func<IHttpRequest, IHttpResponse> func)
        {
            routes[requestMethod].Add(path,func);
           
        }

        public bool Contains(HttpRequestMethod method, string path)
        {
            return routes.ContainsKey(method) && routes[method].ContainsKey(path);
        }

        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path)
        {
            return routes[requestMethod][path];
        }
    }
}