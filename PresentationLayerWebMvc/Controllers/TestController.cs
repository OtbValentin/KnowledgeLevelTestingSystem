using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using DependenciesConfig;
using Ninject;
using PresentationLayerWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerWebMvc.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }
        // GET: Test
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<TestIndexViewModel> tests = testService.GetAll().Select(test => new TestIndexViewModel()
            {
                Id = test.Id,
                Title = test.Title,
                QuestionsQuantity = test.Questions.Count(),
                TimeToSubmit = new TimeSpan(0, 0, 10, 0, 0)
            }).ToList();

            return View(tests);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Test test = testService.GetById(id);

            if (test == null)
            {
                return HttpNotFound();
            }

            return View(new TestDeleteViewModel() { Id = test.Id, Title = test.Title });
            //return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = testService.GetById(id);

            if (test == null)
            {
                return HttpNotFound();
            }

            testService.Delete(test);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Check test integrity
        [HttpPost]
        public ActionResult Create(TestCreateViewModel test)
        {
            IKernel kernel = new StandardKernel(new BindingModule());
            ITestService testService = kernel.Get<ITestService>();

            IEnumerable<TestQuestion> testQuestions = test.Questions.Select(q => new TestQuestion()
            {
                Text = q.Text,
                AnswerOptions = q.Answers.Split(';'),
                CorrectAnswer = q.CorrectAnswer
            }).ToList();

            Test newTest = new Test() { Title = test.Title, Questions = testQuestions, Category = new TestCategory() { Name = "Countries", Id = 1} };
            testService.Create(newTest);

            return RedirectToAction("Create");
        }
    }
}