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

        private double throttleVal = 0;
        private double elevatorVal = 0;
        private double aileronVal = 0;
        private double rudderVal = 0;


        public double Throttle
        {
            get
            {
                return throttleVal;
            }
            set
            {
                throttleVal = Math.Round(value, 2);
                NotifyPropertyChanged("Throttle");
                string setThrottle = throttlePath + throttleVal + " " + "\r\n";
                CommandModel.Instance.SendMessage(setThrottle);
            }
        }

       
        public double Elevator
        {
            get
            {
                return elevatorVal;
            }
            set
            {
                elevatorVal = Math.Round(value, 2);
                NotifyPropertyChanged("Elevator");
                string setElevator = elevatorPath + elevatorVal + " " + "\r\n";
                CommandModel.Instance.SendMessage(setElevator);
            }
        }

        
        public double Aileron
        {
            get
            {
                return aileronVal;
            }
            set
            {
                aileronVal = Math.Round(value, 2);
                NotifyPropertyChanged("Aileron");
                string setAileron = aileronPath + aileronVal + " " + "\r\n";
                CommandModel.Instance.SendMessage(setAileron);
            }
        }

        
        public double Rudder
        {
            get
            {
                return rudderVal;
            }
            set
            {
                rudderVal = Math.Round(value, 2);
                NotifyPropertyChanged("Rudder");
                string setRudder = rudderPath + rudderVal + " " + "\r\n";
                CommandModel.Instance.SendMessage(setRudder);
            }
        }
    }
}
