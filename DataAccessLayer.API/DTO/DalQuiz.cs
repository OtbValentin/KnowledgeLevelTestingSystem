using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.API.DTO
{
    public class DalQuiz : IUniqueEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<DalQuizQuestion> Questions { get; set; }

        public DalQuizCategory Category { get; set; }

        public DalQuiz()
        {
            Title = string.Empty;
            Questions = new List<DalQuizQuestion>();
        }
    }
}
