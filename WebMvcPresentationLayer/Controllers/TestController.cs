using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcPresentationLayer.Models;
using WebMvcPresentationLayer.Mappers;

namespace WebMvcPresentationLayer.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService testService;
        // GET: Test
        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        public ActionResult Index()
        {
            IEnumerable<Test> tests = testService.GetAll();

            ViewBag.Count = tests.Count();
            ViewBag.Tests = tests;

            return View();
        }

        public ActionResult All()
        {
            IEnumerable<TestViewModel> tests = testService.GetAll().Select(e => e.ToPllTestModel()).ToList();

            return View(tests);
        }

        public ActionResult Add()
        {
            List<TestQuestion> questions = new List<TestQuestion>()
            {
                new TestQuestion() {Text = "Who are u?", AnswerOptions = new string[] {"qew", "zxc", "kgb"}, CorrectAnswer = "kgb" },
                new TestQuestion() {Text = "How old are u?", AnswerOptions = new string[] {"15", "21", "19"}, CorrectAnswer = "19" },
                new TestQuestion() {Text = "What is ur gender?", AnswerOptions = new string[] {"male", "female"}, CorrectAnswer = "male" }
            };

            Test test = new Test()
            {
                Title = "Select a correct answer",
                Questions = questions
            };

            testService.Create(test);

            return View();
        }
    }
}