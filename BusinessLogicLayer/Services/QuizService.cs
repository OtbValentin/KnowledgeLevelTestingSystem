using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API;
using BusinessLogicLayer.API.Services;
using BusinessLogicLayer.API.Entities;
using DataAccessLayer.API;
using BusinessLogicLayer.Mappers;
using DataAccessLayer.API.DTO;

namespace BusinessLogicLayer.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork uow;

        public QuizService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Quiz> GetAll()
        {
            return uow.TestRepository.GetAll().Select(dalTest => dalTest.ToBllTest());
        }

        public void Create(Quiz entity)
        {
            uow.TestRepository.Create(entity.ToDalTest());
            uow.SaveChanges();
        }

        public Quiz GetById(int id)
        {
            DalQuiz quiz = uow.TestRepository.GetById(id);

            if (quiz == null)
            {
                return null;
            }

            return quiz.ToBllTest();
        }

        public void Delete(int id)
        {
            uow.TestRepository.Delete(id);
            uow.SaveChanges();
        }

        public void Update(Quiz entity)
        {
            if (entity != null)
            {
                uow.TestRepository.Update(entity.ToDalTest());
                uow.SaveChanges();
            }
        }
    }
}
