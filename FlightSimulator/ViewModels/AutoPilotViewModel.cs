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
        private ICommand _okCommand;
        private ICommand _clearCommand;

        public AutoPilotModel APModel { get; set; }

        public AutoPilotViewModel()
        {
            APModel = new AutoPilotModel();
            // initialize the background color
            APModel.BackgroundColor = Brushes.White;
            // initialize the text string
            APModel.TextString = "";
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
                APModel.BackgroundColor = Brushes.White;
                // split the text string to commands
                string[] commands = APModel.TextString.Split('\n');
                // goes over all the commands and send them to the simulator with a pause of 2 seconds between each command
                foreach (string cmd in commands)
                {
                    string command = cmd;
                    command += "\r\n";
                    CommandModel.Instance.SendMessage(command);
                    // pause of 2 seconds
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
            // update the text string to be empty
            APModel.TextString = "";
            // update the background color to be white
            APModel.BackgroundColor = Brushes.White;
        }
    }
}
