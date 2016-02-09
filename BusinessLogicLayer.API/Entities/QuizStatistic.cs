using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.API.Entities
{
    public class QuizStatistic
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int QuizId { get; set; }

        public int Correct { get; set; }

        public DateTime DatePassed { get; set; }
    }
}
