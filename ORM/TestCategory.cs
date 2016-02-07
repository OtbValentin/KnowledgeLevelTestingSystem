using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class TestCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
