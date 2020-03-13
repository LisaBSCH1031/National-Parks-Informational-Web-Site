using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web
{
    public static class RandyErrorMessage
    {
        
        public static string GetActError()
        {
            List<string> mess = new List<string>()
            {
                "Although we assume that your Activity Level is Sloth-like, you actually need to click one of those buttons.",
                "Please just pick an Activity Level"
            };
            Random random = new Random();
            int rInt = random.Next(0, 1);
            return mess[rInt];
        }
    }
}
