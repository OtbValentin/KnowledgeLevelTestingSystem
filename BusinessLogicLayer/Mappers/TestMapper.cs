using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.API.Services;
using BusinessLogicLayer.API.Entities;
using DataAccessLayer.API;
using DataAccessLayer.API.DTO;

namespace BusinessLogicLayer.Mappers
{
    public static class TestMapper
    {
        public static Quiz ToBllTest(this DalQuiz dalTest)
        {
            return new Quiz()
            {
                Id = dalTest.Id,
                Title = dalTest.Title,
                Category = dalTest.Category.ToBllTestCategory(),
                Questions = dalTest.Questions.Select(question => question.ToBllTestQuestion()).ToList()
            };
        }

        public static QuizCategory ToBllTestCategory(this DalQuizCategory dalTestCategory)
        {
            return new QuizCategory() { Id = dalTestCategory.Id, Name = dalTestCategory.Name };
        }

        public static QuizQuestion ToBllTestQuestion(this DalQuizQuestion dalTestQuestion)
        {
            return new QuizQuestion()
            {
                Id = dalTestQuestion.Id,
                Text = dalTestQuestion.Text,
                CorrectAnswer = dalTestQuestion.CorrectAnswer,
                AnswerOptions = dalTestQuestion.AnswerOptions.ToList()
            };
        }

        public static DalQuiz ToDalTest(this Quiz test)
        {
            return new DalQuiz()
            {
                Id = test.Id,
                Title = test.Title,
                Category = test.Category.ToDalTestCategory(),
                Questions = test.Questions.Select(question => question.ToDalTestQuestion()).ToList()
            };
        }

        public static DalQuizCategory ToDalTestCategory(this QuizCategory testCategory)
        {
            return new DalQuizCategory() { Id = testCategory.Id, Name = testCategory.Name };
        }

        public static DalQuizQuestion ToDalTestQuestion(this QuizQuestion testQuestion)
        {
            return new DalQuizQuestion()
            {
                Id = testQuestion.Id,
                Text = testQuestion.Text,
                CorrectAnswer = testQuestion.CorrectAnswer,
                AnswerOptions = testQuestion.AnswerOptions.ToList()
            };
        }
    }
}