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
                int answer = ((Low - 32) * (5 / 9));
                return answer;
            }
        }
        public int HighC
        {
            get
            {
                return ((this.High - 32) * (5 / 9));
            }
        }
    }

}
