using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using DataAccessLayer.API;
using BusinessLogicLayer.Mappers;
using DataAccessLayer.API.DTO;

namespace BusinessLogicLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;

        public RoleService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Create(Role role)
        {
            uow.RoleRepository.Create(role.ToDalRole());
            uow.SaveChanges();
        }

        public void Delete(int id)
        {
            uow.RoleRepository.Delete(id);
            uow.SaveChanges();
        }

        public IEnumerable<Role> GetAll()
        {
            return uow.RoleRepository.GetAll().Select(r => r.ToBllRole());
        }

        public Role GetById(int id)
        {
            DalRole dalRole = uow.RoleRepository.GetById(id);

            if (dalRole == null)
            {
                return null;
            }

            return dalRole.ToBllRole();
        }

        public Role GetRoleByName(string name)
        {
            return uow.RoleRepository.GetByName(name).ToBllRole();
        }

        public IEnumerable<Role> GetUserRolesByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void Update(Role role)
        {
            if (role != null)
            {
                uow.RoleRepository.Update(role.ToDalRole());
                uow.SaveChanges();
            }
        }
    }
}
