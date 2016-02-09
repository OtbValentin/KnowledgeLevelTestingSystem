using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.API.DTO;
using BusinessLogicLayer.API.Entities;

namespace BusinessLogicLayer.Mappers
{
    public static class StatisticMapper
    {
        public static QuizStatistic ToBllStatistic(this DalQuizStatistic dalStatistic)
        {
            return new QuizStatistic()
            {
                Id = dalStatistic.Id,
                Correct = dalStatistic.Correct,
                DatePassed = dalStatistic.DatePassed,
                QuizId = dalStatistic.QuizId,
                UserId = dalStatistic.UserId
            };
        }

        public static DalQuizStatistic ToDalStatistic(this QuizStatistic statistic)
        {
            return new DalQuizStatistic()
            {
                Id = statistic.Id,
                Correct = statistic.Correct,
                DatePassed = statistic.DatePassed,
                QuizId = statistic.QuizId,
                UserId = statistic.UserId
            };
        }
    }
}
