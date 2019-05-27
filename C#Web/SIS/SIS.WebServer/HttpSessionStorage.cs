using System.Collections.Concurrent;
using SIS.HTTP.Sessions;
using SIS.HTTP.Sessions.Interfaces;

namespace SIS.WebServer
{
    public static class HttpSessionStorage
    {
        private static readonly ConcurrentDictionary<string, IHttpSession> sessions
            =new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSession(id));

        }

        public static bool ContainsSession(string sessionId)
        {

            return sessions.ContainsKey(sessionId);
        }
    }
}