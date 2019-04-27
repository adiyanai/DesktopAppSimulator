using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    class AutoPilotModel : BaseNotify
    {
        private Brush back;
        private string text;


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
                // if the text is not empty change the background to light pink
                if (!string.IsNullOrEmpty(text))
                {
                    BackgroundColor = Brushes.LightPink;
                }
                // if the text is empty change the background to white
                else
                {
                    BackgroundColor = Brushes.White;
                }
                NotifyPropertyChanged("TextString");
            }
        }
    }
}
