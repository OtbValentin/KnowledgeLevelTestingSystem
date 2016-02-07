using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class User
    {
        public int Id { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreationDate { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }
    }
}
