using SIS.HTTP.Cookies.Interfaces;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Interfaces;

namespace SIS.HTTP.Responce.Interfaces
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