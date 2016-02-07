using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.API.Services;

namespace WebMvcPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService testService;

        public HomeController(ITestService testService)
        {
            this.testService = testService;
        }
        public ActionResult Index()
        {
            //ViewData.Add(testService.)
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}