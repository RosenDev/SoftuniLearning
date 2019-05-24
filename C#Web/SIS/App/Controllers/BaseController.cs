using System;
using System.IO;
using System.Runtime.CompilerServices;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Responce.Interfaces;
using SIS.WebServer.Results;

namespace App.Controllers
{
    public abstract class BaseController
    {
        private const string basePath = "../../../";
        protected IHttpResponse View([CallerMemberName] string view = null)
        {
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;

            string viewContent = File.ReadAllText(basePath+"Views" + "/" + controllerName + "/" + viewName + ".html");
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