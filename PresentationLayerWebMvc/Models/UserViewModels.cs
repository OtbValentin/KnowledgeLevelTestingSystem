using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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

    public class UserEditViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Username { get; set; }

        [Display(Name = "Roles")]
        public List<string> Roles { get; set; }

        public UserEditViewModel()
        {
            Roles = new List<string>();
        }
    }

    public class UserDeleteViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
