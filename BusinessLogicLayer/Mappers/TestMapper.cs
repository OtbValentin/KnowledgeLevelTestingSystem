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
        public static Test ToBllTest(this DalTest dalTest)
        {
            return new Test()
            {
                Id = dalTest.Id,
                Title = dalTest.Title,
                Category = dalTest.Category.ToBllTestCategory(),
                Questions = dalTest.Questions.Select(question => question.ToBllTestQuestion()).ToList()
            };
        }

        public static TestCategory ToBllTestCategory(this DalTestCategory dalTestCategory)
        {
            return new TestCategory() { Id = dalTestCategory.Id, Name = dalTestCategory.Name };
        }

        public static TestQuestion ToBllTestQuestion(this DalTestQuestion dalTestQuestion)
        {
            return new TestQuestion()
            {
                Id = dalTestQuestion.Id,
                Text = dalTestQuestion.Text,
                CorrectAnswer = dalTestQuestion.CorrectAnswer,
                AnswerOptions = dalTestQuestion.AnswerOptions.ToList()
            };
        }

        public static DalTest ToDalTest(this Test test)
        {
            return new DalTest()
            {
                Id = test.Id,
                Title = test.Title,
                Category = test.Category.ToDalTestCategory(),
                Questions = test.Questions.Select(question => question.ToDalTestQuestion()).ToList()
            };
        }

        public static DalTestCategory ToDalTestCategory(this TestCategory testCategory)
        {
            return new DalTestCategory() { Id = testCategory.Id, Name = testCategory.Name };
        }

        public static DalTestQuestion ToDalTestQuestion(this TestQuestion testQuestion)
        {
            return new DalTestQuestion()
            {
                Id = testQuestion.Id,
                Text = testQuestion.Text,
                CorrectAnswer = testQuestion.CorrectAnswer,
                AnswerOptions = testQuestion.AnswerOptions.ToList()
            };
        }
    }
}