using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkSurveyVM
    {
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string ActivityLevel {get; set;}
        public string State { get; set; }
        public Survey survey { get; set; }
        public IList<Park> parks { get; set; }
        public IList<Survey> surveys { get; set; }
        public IList<Survey> parkSurveys { get; set; }
    }
}
