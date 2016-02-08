using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.API.DTO;
using DataAccessLayer.API;
using System.Data.Entity;
using ORM;

namespace DataAccessLayer
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalRole entity)
        {
            Role role = new Role() { Name = entity.Name.ToLower(), Description = entity.Description };

            context.Set<Role>().Add(role);
        }

        public void Delete(int id)
        {
            Role role = context.Set<Role>().FirstOrDefault(r => r.Id == id);

            if (role != null)
            {
                context.Set<Role>().Remove(role);
            }
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(role => new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            });
        }

        public DalRole GetById(int id)
        {
            Role role = context.Set<Role>().FirstOrDefault(r => r.Id == id);

            if (role == null)
            {
                return null;
            }

            return new DalRole() { Id = role.Id, Name = role.Name, Description = role.Description };
        }

        public DalRole GetByName(string name)
        {
            Role role = context.Set<Role>().FirstOrDefault(r => r.Name.ToLower() == name.ToLower());

            if (role == null)
            {
                return null;
            }

            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public void Update(DalRole entity)
        {
            Role role = context.Set<Role>().FirstOrDefault(r => r.Id == entity.Id);

            if (role != null)
            {
                role.Name = entity.Name;
                role.Description = entity.Description;
            }
        }
    }
}
