using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ORM
{
    public class TestingSystemContext : DbContext
    {
        public TestingSystemContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> Questions { get; set; }
        public DbSet<TestCategory> Categories { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
