using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Request;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Responce;
using SIS.HTTP.Responce.Interfaces;
using SIS.HTTP.Sessions;
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
            string sessionId = null;
            if (request.Cookies.ContainsCookie(GlobalConstants.SessionCookieKey))
            {
                var cookie = request.Cookies.GetCookie(GlobalConstants.SessionCookieKey);
                sessionId = cookie.Value;
                request.Session = HttpSessionStorage.GetSession(sessionId);
            }
            else
            {
                request.Session = HttpSessionStorage.GetSession(Guid.NewGuid().ToString());
            }

            return sessionId;
        }

        private void SetResponseSession(IHttpResponse response,string sessionId)
        {
            if (sessionId!=null)
            {
                response.AddCookie(new HttpCookie("SIS_ID",sessionId));
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
            var obj= new object();
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
            return new HttpRequest(req.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest request)
        {
            if (!routingTable.Contains(request.RequestMethod,request.Path))
            {
                return new TextResult($"Route with method {request.RequestMethod} and path \"{request.Path}\" not found",HttpResponseStatusCode.NotFound);

            }

            return routingTable.Get(request.RequestMethod, request.Path)
                .Invoke(request);
        }

        private async Task PrepareResponseAsync(IHttpResponse response)
        {
            var segments = response.GetBytes();
            await client.SendAsync(segments, SocketFlags.None);

        }
    }
}