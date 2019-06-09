using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SIS.HTTP.Enums;
using SIS.HTTP.Request;
using SIS.HTTP.Responce;
using SIS.WebServer.Attributes;
using SIS.WebServer.Attributes.Action;
using SIS.WebServer.Attributes.Validation;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;
using SIS.WebServer.Validation;
using IServiceProvider=SIS.WebServer.DependecyContainer.IServiceProvider;

namespace SIS.WebServer
{
    /// <summary>
    /// The base starer of any SIS MVC App 
    /// </summary>
    public  static class WebHost
    {
        private static readonly IControllerState controllerState = new ControllerState();
        /// <summary>
        /// Starts an mvcApplication
        /// </summary>
        /// <param name="mvcApplication">The mvcApplication</param>
        public static void Start(IMvcApplication mvcApplication)
        {
            IServerRoutingTable routingTable = new ServerRoutingTable();
            var httpSessionStorage = new HttpSessionStorage();
            mvcApplication.Configure(routingTable);
           var serviceProvider= mvcApplication.ConfigureServices();
            AutoRegisterRoutes(mvcApplication,routingTable, serviceProvider);
            var server = new Server(8000, routingTable,httpSessionStorage);
            server.Start();

        }

        private static void AutoRegisterRoutes(IMvcApplication app,IServerRoutingTable table,IServiceProvider provider)
        {
            app.GetType().Assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract 
                                      && x.IsSubclassOf(typeof(Controller)))
                .ToList().ForEach(controller =>
                {
                    var actions = controller
                        .GetMethods(BindingFlags.Public 
                                    | BindingFlags.Instance
                                    |BindingFlags.DeclaredOnly)
                        .Where(x => !x.IsSpecialName && x.DeclaringType == controller)
                        .Where(x => x.GetCustomAttributes().All(a => a.GetType() != typeof(NonActionAttribute)));
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
                    table.Add(httpMethod,path,req=>
                        ProcessRequest(provider, controller, action,req));
              

                    }

                    
                });

        }
        private static IHttpResponse ProcessRequest(
            IServiceProvider serviceProvider,
            Type controllerType,
            MethodInfo action,
            IHttpRequest request)
        {
            var controllerInstance = serviceProvider.CreateInstance(controllerType) as Controller;
            controllerState.SetState(controllerInstance);
            controllerInstance.Request = request;
            
            // Security Authorization - TODO: Refactor this
            var controllerPrincipal = controllerInstance.User;
            var authorizeAttribute = action.GetCustomAttributes()
                .LastOrDefault(a => a.GetType() == typeof(AuthorizedAttribute)) as AuthorizedAttribute;
            if (authorizeAttribute != null && !authorizeAttribute.IsInAuthority(controllerPrincipal))
            {
                //
                return new RedirectResult($"/Users/Login?returnUrl={request.Url}");
            }

            var parameters = action.GetParameters();
            var parameterValues = new List<object>();

            foreach (var parameter in parameters)
            {
                List<object> httpDataValue = TryGetHttpParameter(request, parameter.Name);
                if (parameter.ParameterType.GetInterfaces().Any(
                    i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                    &&parameter.ParameterType!=typeof(string)))
                {
                    var collection = httpDataValue.Select(x => System.Convert.ChangeType(x,
                        parameter.ParameterType.GenericTypeArguments.First()));
                    parameterValues.Add(collection);
                    continue;
                } 

                try
                {
                    string httpStringValue = (string)httpDataValue.FirstOrDefault();
                    var parameterValue = Convert.ChangeType(httpStringValue, parameter.ParameterType);
                    parameterValues.Add(parameterValue);
                }
                catch
                {
                    var paramaterValue = Activator.CreateInstance(parameter.ParameterType);
                    var properties = parameter.ParameterType.GetProperties();
                    foreach (var property in properties)
                    {
                        List<object> propertyHttpDataValue = TryGetHttpParameter(request, property.Name);
                        if (property.PropertyType.GetInterfaces().Any(
                            i => i.IsGenericType &&
                                 i.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                                 && property.PropertyType != typeof(string)))
                        {
                            var propertyValue = (IList)Activator.CreateInstance(property.PropertyType);
                            foreach (var obj in propertyHttpDataValue)
                            {
                                propertyValue.Add(obj);
                            }
                            propertyValue.Add(propertyValue);
                            property.SetMethod.Invoke(paramaterValue, new object[] { propertyValue });
                        }
                        else
                        {
                            var firstValue = propertyHttpDataValue.FirstOrDefault();
                            var propertyValue = Convert.ChangeType(firstValue, property.PropertyType);
                            property.SetMethod.Invoke(paramaterValue, new object[] {propertyValue});
                        }
                    }
                    if (request.RequestMethod == HttpRequestMethod.Post)
                    {
                        controllerState.Reset();
                        controllerInstance.ModelState = ValidateObject(paramaterValue);
                        controllerState.Initialize(controllerInstance);
                    }
                    parameterValues.Add(paramaterValue);
                }
            }

            var response = action.Invoke(controllerInstance, parameterValues.ToArray()) as ActionResult;
            return response;
        }

        private static ModelStateDictionary ValidateObject(object value)
        {
            var modelState= new ModelStateDictionary();
            var properties = value.GetType().GetProperties();
            foreach (var property in properties)
            {
                var validationAttributes = property
                    .GetCustomAttributes()
                    .Where(x => x is ValidationAttribute)
                    .Cast<ValidationAttribute>()
                    .ToList();
                foreach (var validationAttribute in validationAttributes)
                {
                    if (validationAttribute.IsValid(property.GetValue(value)))
                    {
                        continue;
                    }
                    modelState.Add(property.Name,validationAttribute.ErrorMessage);
                }
            }

            return modelState;
        }
        private static List<object> TryGetHttpParameter(IHttpRequest request, string parameterName)
        {
            parameterName = parameterName.ToLower();
            List<object> httpDataValue = null;
            if (request.QueryData.Any(x => x.Key.ToLower() == parameterName))
            {
                httpDataValue = request.QueryData.FirstOrDefault(
                    x => x.Key.ToLower() == parameterName).Value;
            }
            else if (request.FormData.Any(x => x.Key.ToLower() == parameterName))
            {
                httpDataValue = request.FormData.FirstOrDefault(
                    x => x.Key.ToLower() == parameterName).Value;
            }

            return httpDataValue;
        }
    }
}
    