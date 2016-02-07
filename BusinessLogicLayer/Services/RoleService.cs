using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using DataAccessLayer.API;
using BusinessLogicLayer.Mappers;

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

        public void Delete(Role role)
        {
            uow.RoleRepository.Delete(role.ToDalRole());
            uow.SaveChanges();
        }

        public IEnumerable<Role> GetAll()
        {
            return uow.RoleRepository.GetAll().Select(r => r.ToBllRole());
        }

        public Role GetRoleByName(string name)
        {
            return uow.RoleRepository.GetByName(name).ToBllRole();
        }

        public IEnumerable<Role> GetUserRolesByEmail(string email)
        {
            //return uow.RoleRepository.

            return new List<Role>();
        }
    }
}
