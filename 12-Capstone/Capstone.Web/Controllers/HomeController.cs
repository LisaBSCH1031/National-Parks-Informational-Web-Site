using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParksDAO parksDAO;
        public HomeController(IParksDAO parksDAO)
        {
            this.parksDAO = parksDAO;
        }
        public IActionResult Index()
        {
            IList<Park> park = parksDAO.GetAllParks();
            return View(park);
        }

        public IActionResult Detail(string id)
        {
            Park park = parksDAO.GetPark(id);
            return View(park);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
