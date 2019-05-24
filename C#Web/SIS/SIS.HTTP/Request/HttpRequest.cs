using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Interfaces;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Interfaces;
using SIS.HTTP.Request.Interfaces;
using SIS.HTTP.Sessions.Interfaces;

namespace SIS.HTTP.Request
{
    public class HttpRequest:IHttpRequest
    {
        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, List<object>> FormData { get; private set; }
        public IHttpSession Session { get; set; }
        public Dictionary<string, List<object>> QueryData { get; private set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpCookieCollection Cookies { get; set; }

        private void ParseCookies()
        {
            if (Headers.ContainsHeader(GlobalConstants.HttpHeaderCookie))
            {
                var value = Headers.GetHeader(GlobalConstants.HttpHeaderCookie).Value;
                var unparsedCookies = value.Split("; ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var unparsedCookie in unparsedCookies)
                {
                    var cookieKvp = unparsedCookie.Split("=");
                    IHttpCookie cookie= new HttpCookie(cookieKvp[0],cookieKvp[1],false);
                    Cookies.AddCookie(cookie);
                }
            }
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length==3)
            {
                if (requestLine[2]=="HTTP/1.1")
                {
                    return true;
                }

               
            }

            if (requestLine.Length==2)
            {
                if (requestLine[1]=="HTTP/1.1")
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParams)
        {
            CoreValidator.ThrowIfEmpty(queryString,nameof(queryString));
            return queryParams.Length >= 1;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            RequestMethod = Enum.Parse<HttpRequestMethod>(requestLine[0], true);

        }

        private void ParseRequestUrl(string[] requestLine)
        {
            Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            Path = Path = Url.Split("?")[0];
        }

        private void ParseHeaders(string[] requestContent)
        {
          
            requestContent
                   
                
                .ToList().ForEach(x =>
                {
                    Headers.AddHeader(new HttpHeader(x.Split(": ")[0], x.Split(": ")[1]));
                });
            if (!Headers.ContainsHeader("Host"))
            {
                throw new BadRequestException();
            }
        }

        private void ParseQueryParameters()
        {
            if (Url.Contains("?"))
            {
                var urlParts = Url.Split("?");
                var hashtagIndex = Url.IndexOf("#");
                var urlParams = string.Join("", urlParts[1].Take(hashtagIndex - (1 + urlParts[0].Length)).ToList());

                if (!IsValidRequestQueryString(urlParts[1],urlParts[1].Split("&")))
                {
                    throw new BadRequestException();
                }
                foreach (var s in urlParams.Split("&"))
                {
                    var keyValue = s.Split("=");
                    if (!QueryData.ContainsKey(keyValue[0]))
                    {

                        QueryData.Add(keyValue[0], new List<object>{keyValue[1]});

                    }
                    else
                    {
                        QueryData[keyValue[0]].Add(keyValue[1]);
                    }
                }
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            if (!string.IsNullOrEmpty(formData))
            {


                formData.Split("&").ToList()
                    .ForEach(param =>
                    {
                        var keyValue = param.Split("=");
                        if (!FormData.ContainsKey(keyValue[0]))
                        {
                            FormData.Add(keyValue[0], new List<object>{keyValue[1]});
                        }
                        else
                        {
                            FormData[keyValue[0]].Add(keyValue[1]);
                        }
                    });
            }

        }
      
        /// <summary>
        /// Parses th formData
        /// For multiple parameters it stores all of them in one string of the same parameter key
        /// </summary>
        /// <param name="formData"></param>
        private void ParseRequestParameters(string formData)
        {
            ParseFormDataParameters(formData);
            ParseQueryParameters();
        }

        private void ParseRequest(string requestString)
        {
          
            var requestContent = requestString.Split(GlobalConstants.HttpNewLine);
            var firstLine = requestContent[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (!IsValidRequestLine(firstLine))
            {
                throw new BadRequestException();
            }
            ParseRequestMethod(firstLine);
            ParseCookies();
            var newLineIndex = Array.LastIndexOf(requestContent, "");
            if (newLineIndex==-1)
            {
                ParseHeaders(requestContent.Skip(1).ToArray());
                ParseRequestParameters("");
            }
            else
            {
                ParseHeaders(requestContent.Skip(1)
                    .Take(newLineIndex - 2).ToArray());

                if (newLineIndex==requestContent.Length-1)
                {

                    ParseRequestParameters("");
                }
                else
                {
                    ParseRequestParameters(requestContent[newLineIndex + 1]);
                }
            }
            ParseRequestUrl(firstLine);
            ParseRequestPath();
            

        }

        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfEmpty(requestString,nameof(requestString));
            FormData = new Dictionary<string, List<object>>();
            QueryData = new Dictionary<string, List<object>>();
            Cookies=new HttpCookieCollection();
            Headers = new HttpHeaderCollection();
            Url = string.Empty;
            ParseRequest(requestString);
           
            
           
        }
    }
}