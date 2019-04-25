using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        private bool isConnect = false;

        public FlightBoardViewModel()
        {
            InfoModel.Instance.PropertyChanged += PropertyChange;
        }
        public double Lon
        {
            get { return InfoModel.Instance.Lon; }
            set { InfoModel.Instance.Lon = value; }
        }

        public double Lat
        {
            get { return InfoModel.Instance.Lat; }
            set { InfoModel.Instance.Lat = value; }
        }

        public void PropertyChange(object sender, PropertyChangedEventArgs p)
        {
            NotifyPropertyChanged(p.PropertyName);
        }

        public ICommand DisConnectCommand
        {
            get
            {
                return new CommandHandler(() => OnClickDisConnect());
            }
        }

        public ICommand SettingsCommand
        {
            get
            {
                return new CommandHandler(() => OnClickSetting());
            }
        }

        public ICommand ConnectCommand
        {
            get
            {
                return new CommandHandler(() => OnClickConnect());
            }
        }

        public void OnClickSetting()
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        public void OnClickConnect()
        {
            if (!isConnect)
            {
                this.isConnect = true;
                Thread thread = new Thread(() =>
                {
                    InfoModel.Instance.Connect();
                    CommandModel.Instance.Connect();
                });
                thread.Start();
            }
        }

        public void OnClickDisConnect()
        {
            if (isConnect)
            {
                this.isConnect = false;
                InfoModel.Instance.Stop();
                Command.Instance.Close();
            }
        }
    }
}