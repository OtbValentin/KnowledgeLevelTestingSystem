using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class QuizCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Quiz> Tests { get; set; }
    }
}
