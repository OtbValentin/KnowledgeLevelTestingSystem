using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
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
        private readonly IQuizService quizService;

        public QuizController(IQuizService testService)
        {
            this.quizService = testService;
        }
        // GET: Quizz
        public ActionResult Index()
        {
            IEnumerable<QuizIndexViewModel> quizzes = quizService.GetAll().Select(quiz => new QuizIndexViewModel()
            {
                Id = quiz.Id,
                Title = quiz.Title,
                QuestionsQuantity = quiz.Questions.Count(),
                TimeToSubmit = new TimeSpan(0, 0, 10, 0, 0)
            }).ToList();

            return View(quizzes);
        }

        [HttpPost]
        public ActionResult Result(SubmittedQuizViewModel test)
        {
            Quiz passedTest = quizService.GetById(test.Id);

            QuizResultViewModel result = new QuizResultViewModel()
            { Title = passedTest.Title, Questions = new List<QuizQuestionResultViewModel>() };

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
        public ActionResult Pass(int id)
        {
            Quiz quiz = quizService.GetById(id);

            if (quiz == null)
            {
                return HttpNotFound();
            }

            QuizPassViewModel quizView = new QuizPassViewModel()
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Questions = quiz.Questions.Select(question => new QuizQuestionPassViewModel()
                {
                    Text = question.Text,
                    Answers = question.AnswerOptions.ToArray(),
                }).ToList()
            };

            return View(quizView);
        }

        // GET: Quizz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quizz/Create
        public ActionResult Create()
        {
            return View();
        }

        // Categories
        // POST: Quizz/Create
        [HttpPost]
        public ActionResult Create(QuizCreateViewModel quiz)
        {
            try
            {
                IEnumerable<QuizQuestion> quizQuestions = quiz.Questions.Select(q => new QuizQuestion()
                {
                    Text = q.Text,
                    AnswerOptions = q.Answers.Split(';'),
                    CorrectAnswer = q.CorrectAnswer
                }).ToList();

                Quiz newTest = new Quiz() { Title = quiz.Title, Questions = quizQuestions, Category = new QuizCategory() { Name = "Countries", Id = 1 } };
                quizService.Create(newTest);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quizz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quizz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quizz/Delete/5
        public ActionResult Delete(int id)
        {
            Quiz quiz = quizService.GetById(id);

            if (quiz == null)
            {
                return HttpNotFound();
            }

            QuizDeleteViewModel model = new QuizDeleteViewModel() { Id = quiz.Id, Title = quiz.Title };

            return View(model);
        }

        // POST: Quizz/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Quiz quiz = quizService.GetById(id);

                if (quiz == null)
                {
                    return HttpNotFound();
                }

                quizService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
