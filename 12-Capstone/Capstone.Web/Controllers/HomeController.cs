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
        [HttpGet]
        public IActionResult Detail(string id, ParkWeatherVM vm)
        {
            vm.TempChoice = HttpContext.Session.GetString("temp");
            if(vm.TempChoice == null)
            {
                vm.TempChoice = "Fahrenheit";
            }


            vm.park = parksDAO.GetPark(id);
            vm.weather = weatherDAO.GetWeather(id);
            vm.weatherDays = weatherDAO.GetWeatherDays(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Detail(ParkWeatherVM vm)
        {
            string tempchoice = vm.TempChoice;
            HttpContext.Session.SetString("temp", tempchoice);

            return RedirectToAction("Detail", vm);
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
