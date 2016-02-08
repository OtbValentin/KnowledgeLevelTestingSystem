using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerWebMvc.Models
{
    public class RoleDisplayViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class RoleCreateViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class RoleEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
