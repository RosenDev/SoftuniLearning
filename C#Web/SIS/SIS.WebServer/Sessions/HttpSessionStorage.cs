using System.Collections.Concurrent;
using SIS.HTTP.Sessions;

namespace SIS.WebServer
{
    public class HttpSessionStorage:IHttpSessionStorage
    {
        private readonly ConcurrentDictionary<string, IHttpSession> sessions
            =new ConcurrentDictionary<string, IHttpSession>();

        public IHttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSession(id));

        }

        public bool ContainsSession(string sessionId)
        {

            return sessions.ContainsKey(sessionId);
        }
    }
}