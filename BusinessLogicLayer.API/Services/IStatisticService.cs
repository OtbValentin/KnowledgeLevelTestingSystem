using BusinessLogicLayer.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.API.Services
{
    public interface IStatisticService
    {
        IEnumerable<QuizStatistic> GetAll();
        IEnumerable<QuizStatistic> GetUserStatistic(int userId);
        QuizStatistic GetById(int id);
        void Create(QuizStatistic statistic);
        void Delete(int id);
    }
}
