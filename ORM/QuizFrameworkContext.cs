using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ORM
{
    public class QuizFrameworkContext : DbContext
    {
        public QuizFrameworkContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Quiz> Tests { get; set; }
        public DbSet<QuizQuestion> Questions { get; set; }
        public DbSet<QuizCategory> Categories { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuizStatistic> Statistics { get; set; }
    }
}
