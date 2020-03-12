using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web
{
    public static class NumberGen
    {
        public static string GetRandom()
        {
            Random random = new Random();
            int randomInt = random.Next(1, 10);
            return randomInt.ToString();
        }
    }
}
