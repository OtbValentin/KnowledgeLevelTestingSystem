using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.API.Entities
{
    public class User
    {
        public int Id { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
