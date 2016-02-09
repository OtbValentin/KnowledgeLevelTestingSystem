using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerWebMvc.Models
{
    public class StatisticViewModel
    {
        [Display(Name = "Quiz")]
        public string QuizTitle { get; set; }

        [Display(Name = "Passed")]
        public DateTime DatePassed { get; set; }

        public int Total { get; set; }

        public int Correct { get; set; }
    }
}
