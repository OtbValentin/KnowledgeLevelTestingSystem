using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class QuizQuestion
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }

        public int TestId { get; set; }

        public virtual Quiz Test { get; set; }

        public QuizQuestion()
        {
            AnswerOptions = new List<AnswerOption>();
        }
    }
}
