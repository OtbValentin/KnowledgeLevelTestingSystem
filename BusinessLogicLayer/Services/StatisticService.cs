using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Services;
using DataAccessLayer.API.DTO;
using DataAccessLayer.API;
using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.Mappers;

namespace BusinessLogicLayer.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork uow;

        public StatisticService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Create(QuizStatistic statistic)
        {
            uow.StatisticRepository.Create(statistic.ToDalStatistic());
            uow.SaveChanges();
        }

        public void Delete(int id)
        {
            uow.StatisticRepository.Delete(id);
            uow.SaveChanges();
        }

        public IEnumerable<QuizStatistic> GetAll()
        {
            return uow.StatisticRepository.GetAll().Select(statistic => statistic.ToBllStatistic());
        }

        public QuizStatistic GetById(int id)
        {
            DalQuizStatistic statistic = uow.StatisticRepository.GetById(id);

            if (statistic == null)
            {
                return null;
            }

            return statistic.ToBllStatistic();
        }

        public IEnumerable<QuizStatistic> GetUserStatistic(int userId)
        {
            return uow.StatisticRepository.GetUserStatistics(userId).Select(dalStatistic => dalStatistic.ToBllStatistic());
        }
    }
}
