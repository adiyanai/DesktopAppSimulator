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
        public JoystickViewModel()
        {
        
        }

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
                string setThrottle = "set /controls/engines/current-engine/throttle " + throttle;
                //לעדכן את הערך אצל המטוס
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
                string setElevator = "set /controls/flight/elevator " + elevator;
                //לעדכן את הערך אצל המטוס
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
                string setAileron = "set /controls/flight/aileron " + aileron;
                //לעדכן את הערך אצל המטוס
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
                string setRudder = "set /controls/flight/rudder " + rudder;
                //לעדכן את הערך אצל המטוס
            }
        }
    }
}
