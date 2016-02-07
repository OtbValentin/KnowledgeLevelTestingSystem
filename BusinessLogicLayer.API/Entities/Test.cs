using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.API.Entities
{
    public class Test
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TestCategory Category { get; set; }

        public IEnumerable<TestQuestion> Questions { get; set; }
    }
}
