using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMvcPresentationLayer.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<TestQuestionViewModel> Questions { get; set; }
    }
}
