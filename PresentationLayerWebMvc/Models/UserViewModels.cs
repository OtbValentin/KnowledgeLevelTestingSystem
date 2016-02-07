using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerWebMvc.Models
{
    public class UserDisplayViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Created")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Roles")]
        public string Roles { get; set; }
    }
}
