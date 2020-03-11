using System;
using System.Collections.Generic;
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
        public IActionResult Index(ParkSurveyVM vm)
        {
            vm.survey = new Survey();
            vm.parks = parksDAO.GetAllParks();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(Survey survey)
        {
            survey.date = DateTime.Now;
            surveyResultDAO.AddSurvey(survey);
            return View();
        }
    }
}