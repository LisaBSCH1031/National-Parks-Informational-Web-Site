using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParksDAO parksDAO;
        private IWeatherDAO weatherDAO;
        public HomeController(IParksDAO parksDAO, IWeatherDAO weatherDAO)
        {
            this.parksDAO = parksDAO;
            this.weatherDAO = weatherDAO;
        }
        public IActionResult Index()
        {
            IList<Park> park = parksDAO.GetAllParks();
            return View(park);
        }

        public IActionResult Detail(string id, ParkWeatherVM vm)
        {
            //Park park = parksDAO.GetPark(id);
            //Weather wthr = weatherDAO.GetWeather(id);
            vm.park = parksDAO.GetPark(id);
            vm.weather = weatherDAO.GetWeather(id);
            vm.weatherDays = weatherDAO.GetWeatherDays(id);
            //foreach(Weather forcast in vm.weather)
            //{
            //    forcast.ConvertToC();
            //}
            return View(vm);
        }

        public IActionResult DetailCelcius(string id, ParkWeatherVM vm)
        {
            vm.park = parksDAO.GetPark(id);
            vm.weather = weatherDAO.GetWeather(id);
            vm.weatherDays = weatherDAO.GetWeatherDays(id);
            return View(vm);
        }
        public IActionResult DetailK(string id, ParkWeatherVM vm)
        {
            vm.park = parksDAO.GetPark(id);
            vm.weather = weatherDAO.GetWeather(id);
            vm.weatherDays = weatherDAO.GetWeatherDays(id);
            return View(vm);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
