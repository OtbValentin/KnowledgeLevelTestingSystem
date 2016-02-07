using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.API.DTO
{
    public class DalTestCategory : IUniqueEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
