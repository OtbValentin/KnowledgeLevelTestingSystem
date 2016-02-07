using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class TestQuestion
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }

        public TestQuestion()
        {
            AnswerOptions = new List<AnswerOption>();
        }
    }
}
