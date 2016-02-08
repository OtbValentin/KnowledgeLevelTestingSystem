using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Entities;

namespace BusinessLogicLayer.API.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Role GetRoleByName(string name);
        IEnumerable<Role> GetUserRolesByEmail(string email);
        void Create(Role role);
        void Delete(Role role);
        void Update(Role role);
        Role GetById(int id);
    }
}
