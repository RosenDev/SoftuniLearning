using System;
using SIS.HTTP.Enums;

namespace SIS.WebServer.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public  class BaseHttpAttribute:Attribute
    {
        public virtual string Name { get; }
        public virtual HttpRequestMethod RequestMethod { get; }
        public virtual string Path { get; }
        public virtual string Action { get; }
    }
}
