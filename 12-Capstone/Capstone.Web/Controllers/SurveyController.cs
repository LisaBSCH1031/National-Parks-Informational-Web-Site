using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private IParksDAO parksDAO;
        private ISurveyResultDAO surveyResultDAO;
        public SurveyController(IParksDAO parksDAO, ISurveyResultDAO surveyResultDAO)
        {
            this.parksDAO = parksDAO;
            this.surveyResultDAO = surveyResultDAO;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ParkSurveyVM vm = new ParkSurveyVM();
            vm.survey = new Survey();
            vm.parks = parksDAO.GetAllParks();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(ParkSurveyVM vm)
        {
            //parksDAO.GetPark(vm.ParkCode);
            if(!ModelState.IsValid)
            {
                return View();
            }
            surveyResultDAO.AddSurvey(vm);
            return RedirectToAction("GetSurveyResults");
        }
        public IActionResult GetSurveyResults()
        {
            IList<SurveyResultVM> list = surveyResultDAO.GetAllParkNamesWithSurvey();
            return View(list);
        }

    }
}