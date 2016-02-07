using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.API;
using DataAccessLayer.API.DTO;
using Ninject;
using ORM;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalUser entity)
        {
            User user = new User()
            {
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                CreationDate = entity.CreationDate,
                Roles = GetRoles(entity.Roles.Select(r => r.Name)).ToList()
            };

            context.Set<User>().Add(user);
        }

        public void Delete(DalUser entity)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Id == entity.Id);

            if (user != null)
            {
                context.Set<User>().Remove(user);
            }
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                CreationDate = user.CreationDate,
                PasswordHash = user.PasswordHash,
                Roles = user.Roles.Select(role => new DalRole() { Id = role.Id, Name = role.Name, Description = role.Description }).ToList()
            });
        }

        public DalUser GetById(int id)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                CreationDate = user.CreationDate,
                PasswordHash = user.PasswordHash,
                Roles = user.Roles.Select(r => new DalRole() { Id = r.Id, Name = r.Name, Description = r.Description }).ToList()
            };
        }

        public DalUser GetByEmail(string email)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null;
            }

            return new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                CreationDate = user.CreationDate,
                PasswordHash = user.PasswordHash,
                Roles = user.Roles.Select(role => new DalRole() { Id = role.Id, Name = role.Name, Description = role.Description }).ToList()
            };
        }

        public void Update(DalUser entity)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Id == entity.Id);

            if (user != null)
            {
                user.PasswordHash = entity.PasswordHash;
                user.Roles = GetRoles(entity.Roles.Select(r => r.Name)).ToList();
            }
        }

        private IEnumerable<Role> GetRoles(IEnumerable<string> roleNames)
        {
            roleNames = roleNames.Select(name => name.ToLower());
            IEnumerable<Role> avaliableRoles = context.Set<Role>().ToList();
            List<Role> roles = new List<Role>();

            foreach (Role role in avaliableRoles)
            {
                if (roleNames.Contains(role.Name.ToLower()))
                {
                    roles.Add(role);
                }
            }

            return roles;
        }
    }
}
