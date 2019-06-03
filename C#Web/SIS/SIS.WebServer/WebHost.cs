using System;
using System.Linq;
using System.Reflection;
using SIS.HTTP.Enums;
using SIS.HTTP.Responce;
using SIS.WebServer.Attributes;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;

namespace SIS.WebServer
{
    public  static class WebHost
    {
        public static void Start(IMvcApplication app)
        {
            IServerRoutingTable table = new ServerRoutingTable();  
            app.Configure(table);
            app.ConfigureServices();
            AutoRegisterRoutes(app,table);
            var server = new Server(8000, table);
            server.Start();

        }

        private static void AutoRegisterRoutes(IMvcApplication app,IServerRoutingTable table)
        {
            app.GetType().Assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract 
                                      && x.IsSubclassOf(typeof(BaseController)))
                .ToList().ForEach(controller =>
                {
                    var actions = controller
                        .GetMethods(BindingFlags.Public 
                                    | BindingFlags.Instance
                                    |BindingFlags.DeclaredOnly)
                        .Where(method => !method.IsStatic&&!method.IsVirtual);
                    foreach (var action in actions)
                    {
                        var path = $"/{controller.Name.Replace("Controller", string.Empty)}/{action.Name}";
                    var attribute = action.GetCustomAttributes().LastOrDefault(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute))) as BaseHttpAttribute;

                    var httpMethod = HttpRequestMethod.Get;
                    if (attribute!=null)
                    {
                        httpMethod = attribute.RequestMethod;
                    }

                    if (attribute?.Path!=null)
                    {
                        path = attribute.Path;
                    }

                    if (attribute?.Action!=null)
                    {
                        path= $"/{controller.Name.Replace("Controller", string.Empty)}/{attribute.Action}";
                    }

                    table.Add(httpMethod,path, req =>
                    {
                        var controllerInstance = Activator.CreateInstance(controller);
                        ((BaseController) controllerInstance).Request = req;
                        var controllerPrincipal = ((BaseController) controllerInstance).User;
                        var authorizeAttribute = action.GetCustomAttributes()
                            .LastOrDefault(a => a.GetType() == typeof(AuthorizedAttribute)) as AuthorizedAttribute;

                        if (authorizeAttribute != null && !authorizeAttribute.IsInAuthority(controllerPrincipal))
                        {
                            // TODO: Redirect to configured URL
                            return new ForbiddenResult("<h1>403<br/>Forbidden you don't have authority</h1>");
                        }
                        var response = action.Invoke(controllerInstance, new object[0] ) as ActionResult;
                        return response;
                    });

                    }

                    
                });

        }
    }
}