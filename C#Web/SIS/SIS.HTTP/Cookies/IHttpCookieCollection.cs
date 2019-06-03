using System.Collections.Generic;

namespace SIS.HTTP.Cookies
{
    public interface IHttpCookieCollection:IEnumerable<IHttpCookie>
    {
        void AddCookie(IHttpCookie cookie);
        bool ContainsCookie(string key);
        IHttpCookie GetCookie(string key);
        bool HasCookies();
    }
}