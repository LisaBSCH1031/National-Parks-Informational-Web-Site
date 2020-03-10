using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkWeatherVM
    {
       public Park park { get; set; }
       public Weather weather { get; set; }
       public IList<Park> Parks { get; set; }
       public IList<Weather> weatherDays { get; set; }
    }
}
