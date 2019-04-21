using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class JoystickViewModel : BaseNotify
    {
        // the paths to the componants in the xml
        private string throttlePath = "set controls/engines/current-engine/throttle ";
        private string elevatorPath = "set controls/flight/elevator ";
        private string aileronPath = "set controls/flight/aileron ";
        private string rudderPath = "set controls/flight/rudder ";

        private double throttle = 0;
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = Math.Round(value, 2);
                NotifyPropertyChanged("Throttle");
                string setThrottle = throttlePath + throttle + " " + "\r\n";
                CommandModel.Instance.SendMessage(setThrottle);
            }
        }

        private double elevator = 0;
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = Math.Round(value, 2);
                NotifyPropertyChanged("Elevator");
                string setElevator = elevatorPath + elevator + " " + "\r\n";
                CommandModel.Instance.SendMessage(setElevator);
            }
        }

        private double aileron = 0;
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = Math.Round(value, 2);
                NotifyPropertyChanged("Aileron");
                string setAileron = aileronPath + aileron + " " + "\r\n";
                CommandModel.Instance.SendMessage(setAileron);
            }
        }

        private double rudder = 0;
        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = Math.Round(value, 2);
                NotifyPropertyChanged("Rudder");
                string setRudder = rudderPath + rudder + " " + "\r\n";
                CommandModel.Instance.SendMessage(setRudder);
            }
        }
    }
}
