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
    public class QuizController : Controller
    {
        private readonly IQuizService testService;

        public QuizController(IQuizService testService)
        {
            this.testService = testService;
        }

        [HttpGet]
        public ActionResult Pass(int id)
        {
            Quiz requestedTest = testService.GetById(id);

            if (requestedTest == null)
            {
                return HttpNotFound();
            }

            QuizPassViewModel testView = new QuizPassViewModel()
            {
                Id = requestedTest.Id,
                Title = requestedTest.Title,
                Questions = requestedTest.Questions.Select(question => new QuizQuestionPassViewModel()
                {
                    Text = question.Text,
                    Answers = question.AnswerOptions.ToArray(),
                }).ToList()
            };

            return View(testView);
        }

        [HttpPost]
        public ActionResult Result(SubmittedQuizViewModel test)
        {
            Quiz passedTest = testService.GetById(test.Id);

            QuizResultViewModel result = new QuizResultViewModel()
            { Title = passedTest.Title, Questions = new List<QuizQuestionResultViewModel>()};

            for (int i = 0; i < test.Answers.Count; i++)
            {
                QuizQuestion testQuestion = passedTest.Questions.ElementAt(i);

                QuizQuestionResultViewModel questionResult = new QuizQuestionResultViewModel()
                {
                    Text = testQuestion.Text,
                    Answers = testQuestion.AnswerOptions.ToList(),
                    Correct = testQuestion.CorrectAnswer,
                    Selected = test.Answers[i]
                };

                result.Questions.Add(questionResult);
            }

            return View(result);
        }
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<QuizIndexViewModel> tests = testService.GetAll().Select(test => new QuizIndexViewModel()
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
            Quiz test = testService.GetById(id);

            if (test == null)
            {
                return HttpNotFound();
            }

            return View(new QuizDeleteViewModel() { Id = test.Id, Title = test.Title });
            //return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Quiz test = testService.GetById(id);

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
        public ActionResult Create(QuizCreateViewModel test)
        {
            IKernel kernel = new StandardKernel(new BindingModule());
            IQuizService testService = kernel.Get<IQuizService>();

            IEnumerable<QuizQuestion> testQuestions = test.Questions.Select(q => new QuizQuestion()
            {
                Text = q.Text,
                AnswerOptions = q.Answers.Split(';'),
                CorrectAnswer = q.CorrectAnswer
            }).ToList();

            Quiz newTest = new Quiz() { Title = test.Title, Questions = testQuestions, Category = new QuizCategory() { Name = "Countries", Id = 1} };
            testService.Create(newTest);

            return RedirectToAction("Create");
        }
    }
}