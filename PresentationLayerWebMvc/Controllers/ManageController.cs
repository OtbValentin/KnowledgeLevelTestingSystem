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
    public class ManageController : Controller
    {
        private readonly IStatisticService statisticService;
        private readonly IUserService userService;
        private readonly IQuizService quizService;

        public ManageController(IStatisticService statisticService, IUserService userService, IQuizService quizService)
        {
            this.statisticService = statisticService;
            this.userService = userService;
            this.quizService = quizService;
        }

        public ActionResult Index()
        {
            User user = userService.GetByEmail(User.Identity.Name);

            if (user == null)
            {
                return HttpNotFound();
            }

            IEnumerable<QuizStatistic> statistics = statisticService.GetUserStatistic(user.Id);

            IEnumerable<StatisticViewModel> statisticsViewModel = statistics.Select(s => new StatisticViewModel()
            {
                DatePassed = s.DatePassed,
                QuizTitle = quizService.GetById(s.QuizId).Title,
                Correct = s.Correct,
                Total = quizService.GetById(s.QuizId).Questions.Count()
            });

            return View(statisticsViewModel);
        }
    }
}