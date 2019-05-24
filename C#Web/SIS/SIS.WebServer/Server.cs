using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SIS.WebServer.Routing.Interfaces;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalHostIp = "127.0.0.1";
        private readonly int port;
        private readonly TcpListener listener;
        private readonly IServerRoutingTable routingTable;
        private bool isRunning;

        public Server(int port,  IServerRoutingTable routingTable)
        {
            this.port = port;
       listener=new TcpListener(IPAddress.Parse(LocalHostIp),port);
            this.routingTable = routingTable;
            
        }

        public   void Start()
        {
            listener.Start();
            isRunning = true;
            Console.WriteLine($"Server is running on http://{LocalHostIp}:{port}");
            while (isRunning)
            {
                Console.WriteLine($"Waiting for client...");
                var client = listener.AcceptSocket();
                Task.Run(() => Listen(client));
            }
        }

        public async Task Listen(Socket client)
        {
            var connHandler= new ConnectionHandler(client,routingTable);
           await connHandler.ProcessRequestAsync();
        }
    }
}