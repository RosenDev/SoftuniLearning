using System.Collections.Generic;
using System.IO;
using System.Threading;
using SIS.HTTP.Common;

namespace SIS.HTTP.Sessions
{
    public class HttpSession:IHttpSession
    {
        private Dictionary<string, object> parameters;
        public HttpSession(string id)
        {
            parameters=new Dictionary<string, object>();
            Id = id;
            IsNew = true;
        }
        public string Id { get; }
        public bool IsNew { get; set; }

        public object GetParameter(string name)
        {
            CoreValidator.ThrowIfEmpty(name,nameof(name));
            return parameters[name];
        }

        public bool ContainsParameter(string name)
        {
            CoreValidator.ThrowIfEmpty(name, nameof(name));
            return parameters.ContainsKey(name);
        }

        public void AddParameter(string name, object parameter)
        {
            CoreValidator.ThrowIfEmpty(name, nameof(name));
            CoreValidator.ThrowIfNull(parameter, nameof(parameter));
            parameters.Add(name,parameter);
        }

        public void ClearParameters()
        {
            parameters.Clear();
        }
    }
}