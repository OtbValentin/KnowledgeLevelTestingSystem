using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Test
    {
        public int Id { get; set; }

        public string Title { get; set; }
        // Replace with more suited type
        public int? CategoryId { get; set; }

        public virtual TestCategory Category { get; set; }

        public virtual ICollection<TestQuestion> Questions { get; set; }

        public Test()
        {
            Questions = new List<TestQuestion>();
        }
    }
}
