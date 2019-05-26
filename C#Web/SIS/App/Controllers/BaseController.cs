using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce.Interfaces;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public abstract class BaseController
    {
        protected Dictionary<string, object> ViewData = new Dictionary<string, object>();

        
        protected bool IsLoggedIn(IHttpRequest req)
        {
            return req.Session.ContainsParameter("username");
        }

        private const string basePath = "../../../";
        private string ParseTemplate(string viewContent)
        {
            foreach (var param in this.ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }

            return viewContent;
        }
        protected IHttpResponse View([CallerMemberName] string view = null)
        {
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;

            string viewContent = File.ReadAllText(basePath+"Views" + "/" + controllerName + "/" + viewName + ".html");
            viewContent = this.ParseTemplate(viewContent);
            var result= new HtmlResult(viewContent,HttpResponseStatusCode.Ok);
            result.Cookies.AddCookie(new HttpCookie("lang","en"));
            result.Cookies.AddCookie(new HttpCookie("SIS_ID",Guid.NewGuid().ToString()));
            return result;
        }

        protected IHttpResponse Redirect(string url)
        {
            return new RedirectResult(url);
        }
    }
}