using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.API.DTO
{
    public class DalTestQuestion : IUniqueEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IEnumerable<string> AnswerOptions { get; set; }

        public string CorrectAnswer { get; set; }

        public DalTestQuestion()
        {
            AnswerOptions = new List<string>();
        }
    }
}
