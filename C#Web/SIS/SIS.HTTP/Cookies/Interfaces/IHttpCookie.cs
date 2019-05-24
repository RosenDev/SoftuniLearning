using System;

namespace SIS.HTTP.Cookies.Interfaces
{
    public interface IHttpCookie
    {
        string Key { get; set; }
        string Value { get; set; }
        DateTime Expires { get; set; }
        string Path { get; set; }
        bool IsNew { get; set; }
        bool HttpOnly { get; set; }
        void Delete();

    }
}