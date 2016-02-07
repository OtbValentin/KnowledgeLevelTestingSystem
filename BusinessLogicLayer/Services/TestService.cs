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

namespace BusinessLogicLayer.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork uow;

        public TestService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Test> GetAll()
        {
            return uow.TestRepository.GetAll().Select(dalTest => dalTest.ToBllTest());
        }

        public void Create(Test entity)
        {
            uow.TestRepository.Create(entity.ToDalTest());
            uow.SaveChanges();
        }

        public void Delete(Test entity)
        {
            uow.TestRepository.Delete(entity.ToDalTest());
            uow.SaveChanges();
        }

        public Test GetById(int id)
        {
            return uow.TestRepository.GetById(id).ToBllTest();
        }
    }
}
