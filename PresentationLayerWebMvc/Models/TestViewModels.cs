using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerWebMvc.Models
{
    public class TestIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionsQuantity { get; set; }
        public TimeSpan TimeToSubmit { get; set; }
    }

    public class TestEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public IEnumerable<Q>
        //public TimeSpan TimeToSubmit { get; set; }
    }

    public class TestCreateViewModel
    {
        public string Title { get; set; }
        public int MinutesToSubmit { get; set; }
        public List<TestQuestionViewModel> Questions { get; set; }
    }

    public class TestDeleteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class TestQuestionViewModel
    {
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name ="Answers(; delimited)")]
        public string Answers { get; set; }
        
        [Display(Name ="Correct answer")]
        public string CorrectAnswer { get; set; }
    }
}
