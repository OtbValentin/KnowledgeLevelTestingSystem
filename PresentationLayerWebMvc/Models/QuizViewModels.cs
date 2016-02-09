using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PresentationLayerWebMvc.Models
{
    public class QuizPassViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<QuizQuestionPassViewModel> Questions { get; set; }
    }

    public class QuizQuestionPassViewModel
    {
        public string Text { get; set; }

        public string[] Answers { get; set; }

    }

    public class SubmittedQuizViewModel
    {
        public int Id { get; set; }

        public List<string> Answers { get; set; }
    }

    public class QuizResultViewModel
    {
        public string Title { get; set; }

        public List<QuizQuestionResultViewModel> Questions { get; set; }

        public int Correct { get; set; }

        public int Total { get; set; }
    }

    public class QuizQuestionResultViewModel
    {
        public string Text { get; set; }

        public List<string> Answers { get; set; }

        public string Correct { get; set; }

        public string Selected { get; set; }
    }

    public class QuizIndexViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Questions")]
        public int QuestionsQuantity { get; set; }

        [Display(Name = "Time limit")]
        public TimeSpan TimeToSubmit { get; set; }
    }

    public class QuizEditViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Title { get; set; }
        //public IEnumerable<Q>
        //public TimeSpan TimeToSubmit { get; set; }
    }

    public class QuizCreateViewModel
    {
        public string Title { get; set; }

        [Display(Name ="Time(minutes)")]
        public int MinutesToSubmit { get; set; }

        public List<QuizQuestionCreateViewModel> Questions { get; set; }
    }

    public class QuizDeleteViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
    }

    public class QuizQuestionCreateViewModel
    {
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Answers(; delimited)")]
        public string Answers { get; set; }

        [Display(Name = "Correct answer")]
        public string CorrectAnswer { get; set; }
    }
}
