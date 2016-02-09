using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.API;
using DataAccessLayer.API.DTO;
using System.Data.Entity;
using ORM;

namespace DataAccessLayer
{
    public class QuizStatisticRepository : IQuizStatisticRepository
    {
        private readonly DbContext context;

        public QuizStatisticRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalQuizStatistic entity)
        {
            QuizStatistic statisticNode = new QuizStatistic()
            {
                Correct = entity.Correct,
                DatePassed = entity.DatePassed,
                QuizId = entity.QuizId,
                UserId = entity.UserId
            };

            context.Set<QuizStatistic>().Add(statisticNode);
        }

        public void Delete(int id)
        {
            QuizStatistic statisticNode = context.Set<QuizStatistic>().FirstOrDefault(statistic => statistic.Id == id);

            if (statisticNode != null)
            {
                context.Set<QuizStatistic>().Remove(statisticNode);
            }
        }

        public IEnumerable<DalQuizStatistic> GetAll()
        {
            return context.Set<QuizStatistic>().Select(statistic => new DalQuizStatistic()
            {
                Id = statistic.Id,
                Correct = statistic.Correct,
                DatePassed = statistic.DatePassed,
                UserId = statistic.UserId,
                QuizId = statistic.QuizId
            });
        }

        public DalQuizStatistic GetById(int id)
        {
            QuizStatistic statistic = context.Set<QuizStatistic>().FirstOrDefault(node => node.Id == id);

            if (statistic == null)
            {
                return null;
            }

            return new DalQuizStatistic()
            {
                Id = statistic.Id,
                Correct = statistic.Correct,
                DatePassed = statistic.DatePassed,
                UserId = statistic.UserId,
                QuizId = statistic.QuizId
            };
        }

        public IEnumerable<DalQuizStatistic> GetUserStatistics(int id)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return user.Statistics.Select(statistic => new DalQuizStatistic()
            {
                Id = statistic.Id,
                Correct = statistic.Correct,
                DatePassed = statistic.DatePassed,
                UserId = statistic.UserId,
                QuizId = statistic.QuizId
            });
        }

        public void Update(DalQuizStatistic entity)
        {
            throw new NotImplementedException();
        }
    }
}
