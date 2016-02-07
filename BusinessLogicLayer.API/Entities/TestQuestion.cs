using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.API.Entities
{
    public class TestQuestion
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IEnumerable<string> AnswerOptions { get; set; }

        public string CorrectAnswer { get; set; }
    }
}
