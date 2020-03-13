using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkSurveyVM
    {
        public string ParkCode { get; set; }

        [Required(ErrorMessage ="An Email Address is required")]
        [EmailAddress(ErrorMessage = "A valid Email Address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Although we assume that your Activity Level is Sloth-like, you actually need to click one of those buttons.")]
        public string ActivityLevel {get; set;}
        public string State { get; set; }
        public Survey survey { get; set; }
        public IList<Park> parks { get; set; }
        public IList<Survey> surveys { get; set; }
        public IList<Survey> parkSurveys { get; set; }
    }
}
