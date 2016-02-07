using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Entities;
using DataAccessLayer.API.DTO;

namespace BusinessLogicLayer.Mappers
{
    public static class UserMapper
    {
        public static User ToBllUser(this DalUser dalUser)
        {
            return new User()
            {
                Id = dalUser.Id,
                Email = dalUser.Email,
                PasswordHash = dalUser.PasswordHash,
                CreationDate = dalUser.CreationDate,
                Roles = dalUser.Roles.Select(dalRole => new Role()
                {
                    Id = dalRole.Id,
                    Name = dalRole.Name,
                    Description = dalRole.Description
                })
            };
        }

        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                CreationDate = user.CreationDate,
                Roles = user.Roles.Select(role => new DalRole()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                })
            };
        }
    }
}
