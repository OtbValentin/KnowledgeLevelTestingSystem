using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Title { get; set; }
        // Replace with more suited type
        public int? CategoryId { get; set; }

        public virtual QuizCategory Category { get; set; }

        public virtual ICollection<QuizQuestion> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<QuizQuestion>();
        }
    }
}
