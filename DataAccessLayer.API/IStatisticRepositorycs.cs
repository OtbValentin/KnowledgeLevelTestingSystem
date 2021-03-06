﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.API.DTO;

namespace DataAccessLayer.API
{
    public interface IQuizStatisticRepository : IRepository<DalQuizStatistic>
    {
        IEnumerable<DalQuizStatistic> GetUserStatistics(int id);
    }
}
