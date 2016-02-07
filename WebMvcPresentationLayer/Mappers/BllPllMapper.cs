using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMvcPresentationLayer.Models;
using BusinessLogicLayer.API.Entities;

namespace WebMvcPresentationLayer.Mappers
{
    public static class BllPllMapper
    {
        public static TestViewModel ToPllTestModel(this Test test)
        {
            return new TestViewModel()
            {
                Title = test.Title,
                Id = test.Id,
                Questions = test.Questions.Select(q => q.ToPllTestQuestionModel())
            };
        }

        public static TestQuestionViewModel ToPllTestQuestionModel(this TestQuestion question)
        {
            return new TestQuestionViewModel()
            {
                Id = question.Id,
                Text = question.Text,
                AnswerOptions = question.AnswerOptions.ToList(),
                CorrectAnswer = question.CorrectAnswer
            };
        }

    }
}
