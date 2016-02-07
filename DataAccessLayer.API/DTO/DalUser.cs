using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.API.DTO
{
    public class DalUser : IUniqueEntity
    {
        public int Id { get; set; }

        public IEnumerable<DalRole> Roles { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
