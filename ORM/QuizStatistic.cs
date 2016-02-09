using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class QuizStatistic
    {
        public int Id { get; set; }

        public DateTime DatePassed { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }

        public int Correct { get; set; }
    }
}
