using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator.Model
{
    public class Client
    {
        private IPEndPoint ep;
        private TcpClient client;
        public Client()
        {
        }

        public void Connect()
        {
            ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP), 
                ApplicationSettingsModel.Instance.FlightCommandPort);
            this.client = new TcpClient();
            this.client.Connect(ep);
            MessageBox.Show("connected");
        }

        public void SendToServer(string Message)
        {
            if (this.client == null)
            {
                //TODO: make sure the client connect before.
                return;
            }
            NetworkStream stream = this.client.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            {
                writer.Write(Message.ToArray());
            }

        }
        
        public void Close()
        {
            client?.Close();
        }
    }
}