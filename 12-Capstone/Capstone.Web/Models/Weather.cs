using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public int LowC
        {
            get
            {
                return ((Low - 32) * 5 / 9); 
            }
        }
        public int HighC
        {
            get
            {
                return ((this.High - 32) * 5 / 9);
            }
        }
        public int LowK
        {
            get
            {
                return (int)(((Low - 32) * 5 / 9) + 273.15); 
            }
        }
        public int HighK
        {
            get
            {
                return (int)(((this.High - 32) * 5 / 9) + 273.15);
            }
        }
    }

}
