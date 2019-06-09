using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SIS.HTTP.Enums;
using SIS.HTTP.Request;
using SIS.WebServer.Extensions;
using SIS.WebServer.Identity;
using SIS.WebServer.Results;
using SIS.WebServer.Validation;
using SIS.WebServer.ViewEngine;

namespace SIS.WebServer
{
    public abstract class Controller
    {
        private readonly IViewEngine viewEngine;
        public ModelStateDictionary ModelState { get; set; }
        protected Controller()
        {
            viewEngine=new SisViewEngine();
            ModelState=new ModelStateDictionary();
        }
        protected Dictionary<string, object> ViewData = new Dictionary<string, object>();
        public IHttpRequest Request { get; set; }
        public Principal User =>
            this.Request.Session.ContainsParameter("principal")
                ? (Principal)this.Request.Session.GetParameter("principal")
                : null;
        protected bool IsLoggedIn()
        {
            return Request.Session.ContainsParameter("principal");
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

        protected void SignIn(string id, string username)
        {
            Request.Session.AddParameter("principal", new Principal
            {
                Id = id,
                Username = username,
            });
        }

        protected void SignOut()
        {
            Request.Session.ClearParameters();
        }
        
        protected ActionResult View<T>(T model,[CallerMemberName] string view = null)

            where  T:class
        {
  

            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;
            if (viewName.Contains("Confirm"))
            {
                viewName = viewName.Substring(0,viewName.IndexOf("Confirm"));
            }
            string viewContent = System.IO.File.ReadAllText(basePath+"Views" + "/" + controllerName + "/" + viewName + ".html");
            viewContent = viewEngine.GetHtml(viewContent,model,ModelState,User);
            var layout = System.IO.File.ReadAllText(basePath+"Views/"+"_Layout.html");
            layout = viewEngine.GetHtml(layout, model,ModelState, User);
            layout = layout.Replace("RenderBody()", viewContent);
            var result= new HtmlResult(layout,HttpResponseStatusCode.Ok);
            return result;
        }

        protected ActionResult View([CallerMemberName] string view = null)
        {
            return View<object>(null,view);
        }
        protected ActionResult Redirect(string url)
        {
            return new RedirectResult(url);
        }
        protected ActionResult File(byte[] fileContent)
        {
            return new FileResult(fileContent);
        }

        protected ActionResult NotFound(string message = "")
        {
            return new NotFoundResult(message);
        }

        protected ActionResult Json(object obj)
        {
            return new JsonResult(obj.ToJson());
        }
        protected ActionResult Xml(object obj)
        {
            return new XmlResult(obj.ToXml());
        }
    }
}