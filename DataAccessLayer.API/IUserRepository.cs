using DataAccessLayer.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.API
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByEmail(string email);
    }
}
