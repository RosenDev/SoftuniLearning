using System.Threading;
using SIS.HTTP.Enums;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetStatusString(this HttpResponseStatusCode code)
        {
            switch (code)
            {
                case HttpResponseStatusCode.Ok:
                    return "200 OK";
                case HttpResponseStatusCode.InternalServerError:
                    return "ngix\n500 Internal Server Error";
                case HttpResponseStatusCode.Created:
                    return "201 Created";
                case HttpResponseStatusCode.NotFound:
                    return "404\n Not Found";
                case HttpResponseStatusCode.Unauthorized:
                    return "You Are not Authorized!!!";
                case HttpResponseStatusCode.Forbidden:
                    return "403\nForbidden";
                case HttpResponseStatusCode.Found:
                    return "302 Found";
                default:
                    return "Not inserted yet";
            }
        }
    }
}