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
    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuizService quizService;

        public QuizController(IQuizService testService)
        {
            this.quizService = testService;
        }

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
        public ActionResult Result(SubmittedQuizViewModel quiz)
        {
            if (ModelState.IsValid)
            {
                Quiz passedQuiz = quizService.GetById(quiz.Id);

                QuizResultViewModel result = new QuizResultViewModel()
                { Title = passedQuiz.Title, Questions = new List<QuizQuestionResultViewModel>() };

                result.Total = quiz.Answers.Count;

                for (int i = 0; i < quiz.Answers.Count; i++)
                {
                    QuizQuestion testQuestion = passedQuiz.Questions.ElementAt(i);

                    QuizQuestionResultViewModel questionResult = new QuizQuestionResultViewModel()
                    {
                        Text = testQuestion.Text,
                        Answers = testQuestion.AnswerOptions.ToList(),
                        Correct = testQuestion.CorrectAnswer,
                        Selected = quiz.Answers[i]
                    };

                    if (questionResult.Selected == testQuestion.CorrectAnswer)
                    {
                        result.Correct++;
                    }

                    result.Questions.Add(questionResult);
                }

                return View(result);
            }

            return RedirectToAction("Index");
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

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(QuizCreateViewModel quiz)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<QuizQuestion> quizQuestions = quiz.Questions.Select(q => new QuizQuestion()
                    {
                        Text = q.Text,
                        AnswerOptions = q.Answers.Split(';').Where(answer => !string.IsNullOrEmpty(answer)).ToList(),
                        CorrectAnswer = q.CorrectAnswer
                    }).ToList();

                    Quiz newTest = new Quiz() { Title = quiz.Title, Questions = quizQuestions, Category = new QuizCategory() { Name = "Countries", Id = 1 } };
                    quizService.Create(newTest);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "admin")]
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

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
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
