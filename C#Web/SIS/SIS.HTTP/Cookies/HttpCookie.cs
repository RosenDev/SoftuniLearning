using System;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies.Interfaces;
using SIS.HTTP.Responce.Interfaces;

namespace SIS.HTTP.Cookies
{
    public class HttpCookie:IHttpCookie
    {
        private const int DefaultHttpCookieExpirationDate = 3;
        private const string DefaultCookiePath = "/";

        public HttpCookie(string key, string value,bool isNew, int expires = DefaultHttpCookieExpirationDate)
        {
            CoreValidator.ThrowIfEmpty(key,nameof(key));
            CoreValidator.ThrowIfEmpty(value,nameof(value));
            Key = key;
            Value = value;
         
            Expires=DateTime.UtcNow.AddDays(expires);

        }

        public HttpCookie(string key, string value,
            int expires=DefaultHttpCookieExpirationDate, 
            string path = DefaultCookiePath)
        :this(key,value,true,expires)
        {
            Path = path;
        }

        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime Expires { get; set; }
        //todo set default path here?
        public string Path { get; set; }
        public bool IsNew { get; set; } = true;
        public bool HttpOnly { get; set; } = true;

        public void Delete()
        {
            Expires=DateTime.UtcNow.AddDays(-1);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Key}={Value}; Expires={Expires:R}");
            if (HttpOnly)
            {
                sb.Append($"; HttpOnly");
            }

            sb.Append($"; Path={Path}");
            return sb.ToString();

        }
    }
}