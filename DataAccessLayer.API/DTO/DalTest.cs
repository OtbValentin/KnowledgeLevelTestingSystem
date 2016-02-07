using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.API.DTO
{
    public class DalTest : IUniqueEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<DalTestQuestion> Questions { get; set; }

        public DalTestCategory Category { get; set; }

        public DalTest()
        {
            Title = string.Empty;
            Questions = new List<DalTestQuestion>();
        }
    }
}
