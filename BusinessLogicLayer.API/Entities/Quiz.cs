using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.API.Entities
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public QuizCategory Category { get; set; }

        public IEnumerable<QuizQuestion> Questions { get; set; }
    }
}
