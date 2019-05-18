using System;
using System.Runtime.InteropServices;
using SIS.HTTP.Enums;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce;
using SIS.HTTP.Responce.Interfaces;
using SIS.WebServer.Results;

namespace App
{
    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            var content = "<h1>Hi</h1>";
            var res = new HtmlResult(content, HttpResponseStatusCode.Ok);
            var a = res.ToString();
            return  res;
        }
    }
}