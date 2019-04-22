using System;
using FlightSimulator.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        private Brush back;
        private string text;
        private ICommand _okCommand;
        private ICommand _clearCommand;


        public AutoPilotViewModel()
        {
            BackgroundColor = Brushes.White;
            text = "";
        }

        public Brush BackgroundColor
        {
            get
            {
                return back;
            }
            set
            {
                back = value;
                NotifyPropertyChanged("BackgroundColor");
            }
        }

 
        public string TextString
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (!string.IsNullOrEmpty(text))
                {
                    BackgroundColor = Brushes.LightPink;
                }
                NotifyPropertyChanged("TextString");
            }
        }


        public ICommand OKCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OnOKClick()));
            }
        }

        private void OnOKClick()
        {
            new Thread(() =>
            {
                BackgroundColor = Brushes.White;
                string[] commands = TextString.Split('\n');
                foreach (string cmd in commands)
                {
                    string command = cmd;
                    command += "\r\n";
                    CommandModel.Instance.SendMessage(command);
                    Thread.Sleep(2000);
                }
            }).Start();
        }


        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClearClick()));
            }
        }

        private void OnClearClick()
        {
            TextString = "";
            BackgroundColor = Brushes.White;
        }
    }
}
