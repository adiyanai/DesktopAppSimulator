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
                // take just two numbers after the dot
                throttleVal = Math.Round(value, 2);
                NotifyPropertyChanged("Throttle");
                // create the command to the simulator
                string setThrottle = throttlePath + throttleVal + " " + "\r\n";
                // send command
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
                // take just two numbers after the dot
                elevatorVal = Math.Round(value, 2);
                NotifyPropertyChanged("Elevator");
                // create the command to the simulator
                string setElevator = elevatorPath + elevatorVal + " " + "\r\n";
                // send command
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
                // take just two numbers after the dot
                aileronVal = Math.Round(value, 2);
                NotifyPropertyChanged("Aileron");
                // create the command to the simulator
                string setAileron = aileronPath + aileronVal + " " + "\r\n";
                // send command
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
                // take just two numbers after the dot
                rudderVal = Math.Round(value, 2);
                NotifyPropertyChanged("Rudder");
                // create the command to the simulator
                string setRudder = rudderPath + rudderVal + " " + "\r\n";
                // send command
                CommandModel.Instance.SendMessage(setRudder);
            }
        }
    }
}
