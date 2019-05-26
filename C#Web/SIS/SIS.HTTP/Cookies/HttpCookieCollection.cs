using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies.Interfaces;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection:IHttpCookieCollection
    {
        private Dictionary<string, IHttpCookie> cookies;

        public HttpCookieCollection()
        {
            cookies=new Dictionary<string, IHttpCookie>();
        }

        public void AddCookie(IHttpCookie cookie)
        {

            cookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfEmpty(key,nameof(key));
            return cookies.ContainsKey(key);
        }

        public IHttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNull(key,nameof(key));
            return cookies[key];
        }

        public bool HasCookies()
        {
            return cookies.Count != 0;
        }

        public IEnumerator<IHttpCookie> GetEnumerator()
        {
            foreach (var httpCookie in cookies)
            {
                yield return httpCookie.Value;

            }
        }

        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}