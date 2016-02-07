using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using DataAccessLayer.API;
using DataAccessLayer.API.DTO;
using BusinessLogicLayer.Mappers;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Create(User entity)
        {
            uow.UserRepository.Create(entity.ToDalUser());
            uow.SaveChanges();
        }

        public void Delete(User entity)
        {
            uow.UserRepository.Delete(entity.ToDalUser());
            uow.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return uow.UserRepository.GetAll().Select(dalUser => dalUser.ToBllUser());
        }

        public User GetById(int id)
        {
            return uow.UserRepository.GetById(id).ToBllUser();
        }

        public User GetByEmail(string email)
        {
            DalUser user = uow.UserRepository.GetByEmail(email);

            if (user == null)
            {
                return null;
            }

            return user.ToBllUser();
        }
    }
}
