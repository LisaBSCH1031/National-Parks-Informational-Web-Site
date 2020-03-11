using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkSurveyVM
    {
        public Park park { get; set; }
        public Survey survey { get; set; }
        public IList<Park> parks { get; set; }
        public IList<Survey> surveys { get; set; }
    }
}
