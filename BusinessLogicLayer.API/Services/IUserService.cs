using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Entities;

namespace BusinessLogicLayer.API.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        void Create(User entity);
        void Delete(User entity);
        User GetById(int id);
        User GetByEmail(string email);
    }
}
