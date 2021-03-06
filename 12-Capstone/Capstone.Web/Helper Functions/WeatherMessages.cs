﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web
{
    public static class WeatherMessages
    {
        public static string GetWeatherMessage(string forecast, int high, int low)
        {
            int tempDifference = high - low;
            string forecastMessage = "Today should be a very nice day.";
            if (forecast == "snow")
            {
                return forecastMessage = "Snow is expected. Pack snowshoes!";
            }
            else if (forecast == "rain")
            {
                return forecastMessage = "Rain is expected. Pack rain gear and wear waterproof shoes!";
            }
            else if (forecast == "thunderstorms")
            {
                return forecastMessage = "Thunderstorms ahead. Seek shelter and avoid hiking on exposed ridges.";
            }
            else if (forecast == "sunny")
            {
                return forecastMessage = "Today will be sunny. Pack sunblock!";
            }
            else if (high >= 75)
            {
                return forecastMessage = "Today will be quite warm. Bring an extra gallon of water!";
            }
            else if (tempDifference > 20)
            {
                return forecastMessage = "Drastic temperature changes predicted today. Wear breathable layers.";
            }
            else if (low <= 20)
            {
                return forecastMessage = "Freezing temperatures predicted for today. Be careful of exposure to frigid temperatures";
            }
            return forecastMessage;
        }
        public static int ConvertToC(int tempF)
        {
            return ((tempF - 32) * (5 / 9));
        }
        public static int ConvertToF(int tempC)
        {
            return ((tempC * (9 / 5)) + 32);
        }
    }
}
