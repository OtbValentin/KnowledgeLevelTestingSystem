using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Entities;

namespace BusinessLogicLayer.API.Services
{
    public interface ITestService
    {
        IEnumerable<Test> GetAll();
        void Create(Test entity);
        void Delete(Test entity);
        Test GetById(int id);
    }
}
