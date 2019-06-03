using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responce
{
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        IHttpHeaderCollection Headers { get;}
        IHttpCookieCollection Cookies { get;}
        byte[] Content { get; set; }
        void AddHeader(HttpHeader header);

        void AddCookie(IHttpCookie cookie);
        
        byte[] GetBytes();


    }
}