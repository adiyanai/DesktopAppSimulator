using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class Server
    {
        private IPEndPoint ep;
        private TcpListener listener;
        public Server() { }

        public void Connect()
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
            listener = new TcpListener(ep);
            listener.Start();
        }

        public void HandleClient(string Message)
        {
            TcpClient client = listener.AcceptTcpClient();
        }

        public void Close()
        {

        }
    }
}