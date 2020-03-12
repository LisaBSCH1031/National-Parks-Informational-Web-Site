using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class ParkWeatherVM
    {
       public Park park { get; set; }
       public Weather weather { get; set; }
       public IList<Park> Parks { get; set; }
       public IList<Weather> weatherDays { get; set; }

        private int Count = 0;
        public string CountMethod()
        {
            foreach(Weather wthr in weatherDays)
            {
                Count++;
                if(Count == wthr.FiveDayForecastValue)
                {
                    if(Count == 1)
                    {
                        return "Today";
                    }
                    else if(Count == 2)
                    {
                        return "Tomorrow";
                    }
                    else
                    {
                        return $"Day {Count}";
                    }
                }
                Count--; //Subtract 1 so that when the counter adds one, it is still the correct number as it is looping
                continue;
            }
            return " ";
        }
    }
}
