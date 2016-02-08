using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Entities;

namespace BusinessLogicLayer.API.Services
{
    public interface IQuizService
    {
        IEnumerable<Quiz> GetAll();
        void Create(Quiz entity);
        void Delete(int id);
        void Update(Quiz entity);
        Quiz GetById(int id);
    }
}
