using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    public sealed class InfoModel : BaseNotify
    {
        private static readonly InfoModel instance = new InfoModel();
        private string[] valuesFromSim = new string[23];
        private double lon;
        private double lat;
        private bool shouldContinue = true;

        string[] ValuesFromSim
        {
            get { return this.valuesFromSim; }
            set { this.ValuesFromSim = value; }
        }

        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static InfoModel()
        {
        }

        private InfoModel()
        {
        }

        public static InfoModel Instance
        {
            get
            {
                return instance;
            }
        }

        public void Connect()
        {
            shouldContinue = true;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
                ApplicationSettingsModel.Instance.FlightInfoPort);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            MessageBox.Show("after start");
            HandleClient(listener);
        }

        public void HandleClient(TcpListener listener)
        {
            TcpClient client = listener.AcceptTcpClient();
            MessageBox.Show("after connect");
            Thread thread = new Thread(() => ReadFromClient(client, listener));
            thread.Start();
        }

        void ReadFromClient(TcpClient client, TcpListener listener)
        {
            Byte[] bytes;
            while (shouldContinue)
            {
                NetworkStream ns = client.GetStream();
                if (client.ReceiveBufferSize > 0)
                {
                    bytes = new byte[client.ReceiveBufferSize];
                    ns.Read(bytes, 0, client.ReceiveBufferSize);
                    string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                    EditMessage(msg);
                    //MessageBox.Show("the func");
                }
            }
            client.Close();
            listener.Stop();
        }

        void EditMessage(string Message)
        {
            string[] splitwords = Message.Split(',');
            this.valuesFromSim = splitwords;
            try
            {
                Lon = Convert.ToDouble(splitwords[0]);
                Lat = Convert.ToDouble(splitwords[1]);
            } catch (Exception E)
            {
            }
            //MessageBox.Show(valuesFromSim[0]);
        }

        public void Stop()
        {
            this.shouldContinue = false;
        }

    }
}