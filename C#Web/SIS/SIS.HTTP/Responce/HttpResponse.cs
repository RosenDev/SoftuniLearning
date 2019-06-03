using System;
using System.IO;
using System.Net.Http;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responce
{
    public class HttpResponse:IHttpResponse
    {
        public HttpResponse()
        {
            Headers=new HttpHeaderCollection();
            Content=new byte[0];
        }

        public HttpResponse(HttpResponseStatusCode statusCode):this()
        {
            CoreValidator.ThrowIfNull(statusCode,nameof(statusCode));
            StatusCode = statusCode;
            Cookies=new HttpCookieCollection();
        }
        public HttpResponseStatusCode StatusCode { get; set; }
        public IHttpHeaderCollection Headers { get; }
        public IHttpCookieCollection Cookies { get; }
        public byte[] Content { get; set; }
        public void AddHeader(HttpHeader header)
        {
        CoreValidator.ThrowIfNull(header,nameof(header));
        Headers.AddHeader(header);
        }
        public void AddCookie(IHttpCookie cookie)
        {
            
            Cookies.AddCookie(cookie);
        }

        public byte[] GetBytes()
        {
            var bytesWithoutBody = Encoding.UTF8.GetBytes(ToString());
            var bytesWithBody = new byte[bytesWithoutBody.Length+Content.Length];
            for (int i = 0; i < bytesWithoutBody.Length; i++)
            {
                bytesWithBody[i] = bytesWithoutBody[i];
            }

            for (int i = 0; i < bytesWithBody.Length-bytesWithoutBody.Length; i++)
            {
                bytesWithBody[i + bytesWithoutBody.Length] = Content[i];
            }

            return bytesWithBody;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"{GlobalConstants.HttpOneProtocolFragment} {(int) StatusCode} {StatusCode.ToString()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append(Headers)
                .Append(GlobalConstants.HttpNewLine);
            if (Cookies.HasCookies())
            {
                foreach (var httpCookie in Cookies)
                {
                    sb.Append($"Set-Cookie: {httpCookie}")
                        .Append(GlobalConstants.HttpNewLine);
                }
            }
               
                sb.Append(GlobalConstants.HttpNewLine);
            return sb.ToString();
        }
    }
}