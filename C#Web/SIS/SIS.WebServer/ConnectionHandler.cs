using System;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Request;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce;
using SIS.HTTP.Responce.Interfaces;
using SIS.HTTP.Sessions;
using SIS.HTTP.Sessions.Interfaces;
using SIS.WebServer.Results;
using SIS.WebServer.Routing.Interfaces;

namespace SIS.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly IServerRoutingTable routingTable;
        

        public ConnectionHandler(Socket client, IServerRoutingTable routingTable)
        {
            CoreValidator.ThrowIfNull(client,nameof(client));
            CoreValidator.ThrowIfNull(routingTable,nameof(routingTable));
            this.client = client;
            this.routingTable = routingTable;
           
        }

        private string SetRequestSession(IHttpRequest request)
        {
            if (request.Cookies.ContainsCookie(GlobalConstants.SessionCookieKey))
            {
                var cookie = request
                    .Cookies
                    .GetCookie(GlobalConstants.SessionCookieKey);

                string sessionId = cookie.Value;

                if (HttpSessionStorage.ContainsSession(sessionId))
                {
                    request.Session = HttpSessionStorage.GetSession(sessionId);
                }
            }

            if (request.Session == null)
            {
                string sessionId = Guid.NewGuid().ToString();

                request.Session = HttpSessionStorage.GetSession(sessionId);
            }

            return request.Session?.Id;
        }

        private void SetResponseSession(IHttpResponse response,string sessionId)
        {
            IHttpSession responseSession = HttpSessionStorage.GetSession(sessionId);

            if (responseSession.IsNew)
            {
                responseSession.IsNew = false;
                response.AddCookie(new HttpCookie(GlobalConstants.SessionCookieKey, responseSession.Id));
            }
        }
        public async Task ProcessRequestAsync()
        {
            IHttpResponse response = null;
     
            try
            {
                var request =await ReadRequestAsync();
                if (request != null)
                {
                    Console.WriteLine($"Processing: {request.RequestMethod} {request.Path}...");
                    var sessionId = SetRequestSession(request);
                    response = HandleRequest(request);
                   SetResponseSession(response,sessionId);

                }

            }
            catch (BadRequestException e)
            {
               response=new TextResult(e.ToString(), HttpResponseStatusCode.BadRequest);

            }
            catch (Exception e)
            {
                response=new TextResult(e.ToString(),HttpResponseStatusCode.InternalServerError);
            }
           await PrepareResponseAsync(response);
            client.Shutdown(SocketShutdown.Both);
        }

        private async Task<HttpRequest> ReadRequestAsync()
        {
            var req = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);
 
            while (true)
            {
              
                    var bytesToRead = await client.ReceiveAsync(data.Array, SocketFlags.None);
                    if (bytesToRead == 0)
                    {
                        break;
                    }



                    var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, bytesToRead);
                    req.Append(bytesAsString);
                    if (bytesToRead < 1023)
                    {
                        break;
                    }
                

                if (req.Length==0)
                {
                    return null;
                }
               
            }
            var request= new HttpRequest(req.ToString());
            return request;
        }

        private IHttpResponse HandleRequest(IHttpRequest request)
        {
            if (!routingTable.Contains(request.RequestMethod,request.Path))
            {
                return ReturnIfResource(request);

            }


            return routingTable.Get(request.RequestMethod, request.Path)
                .Invoke(request);
        }

        private IHttpResponse ReturnIfResource(IHttpRequest request)
        {
            var basePath = "..\\..\\..\\";
            var assembly = Assembly.GetExecutingAssembly().Location.Replace("SIS.WebServer.dll", "");
            assembly=assembly.Replace("\\", "/");
            var resourcePath = "Resources";
            var requestedResource = request.Path;
            var fullPath =  assembly + resourcePath + requestedResource;
            if (File.Exists(fullPath))
            {
                return new InlineResourceResult(File.ReadAllBytes(fullPath),HttpResponseStatusCode.Ok);

            }
            return new TextResult(HttpResponseStatusCode.NotFound.GetStatusString(),HttpResponseStatusCode.NotFound);
        }

        private async Task PrepareResponseAsync(IHttpResponse response)
        {
            var segments = response.GetBytes();
            await client.SendAsync(segments, SocketFlags.None);

        }
    }
}