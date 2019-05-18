using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Interfaces;

namespace SIS.HTTP.Responce.Interfaces
{
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        IHttpHeaderCollection Headers { get;}
        byte[] Content { get; set; }
        void AddHeader(HttpHeader header);
        byte[] GetBytes();


    }
}