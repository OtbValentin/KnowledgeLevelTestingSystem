using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.API;
using DataAccessLayer.API.DTO;
using System.Data.Entity;
using Ninject;
using ORM;

namespace DataAccessLayer
{
    public class TestRepository : ITestRepository
    {
        private readonly DbContext context;

        public TestRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalTest entity)
        {
            Test test = new Test() { Title = entity.Title, CategoryId = entity.Category.Id };

            test.Questions = entity.Questions.Select(question => new TestQuestion()
            {
                Text = question.Text,
                AnswerOptions = question.AnswerOptions.Select(answer => new AnswerOption()
                {
                    Text = answer,
                    IsCorrect = answer == question.CorrectAnswer ? true : false
                }).ToList()
            }).ToList();

            context.Set<Test>().Add(test);
        }

        public void Delete(DalTest entity)
        {
            Test test = context.Set<Test>().FirstOrDefault(t => t.Id == entity.Id);

            if (test != null)
            {
                context.Set<Test>().Remove(test);
            }
        }

        public IEnumerable<DalTest> GetAll()
        {
            return context.Set<Test>().Select(test => new DalTest()
            {
                Id = test.Id,
                Title = test.Title,
                Category = new DalTestCategory()
                {
                    Id = test.Category.Id,
                    Name = test.Category.Name
                },
                Questions = test.Questions.Select(question => new DalTestQuestion()
                {
                    Id = question.Id,
                    Text = question.Text,
                    AnswerOptions = question.AnswerOptions.Select(a => a.Text).ToList(),
                    CorrectAnswer = question.AnswerOptions.FirstOrDefault(a => a.IsCorrect).Text
                }).ToList()
            });
        }

        public DalTest GetById(int id)
        {
            Test test = context.Set<Test>().FirstOrDefault(t => t.Id == id);

            if (test == null)
            {
                return null;
            }

            return new DalTest()
            {
                Id = test.Id,
                Title = test.Title,
                Category = new DalTestCategory()
                {
                    Id = test.Category.Id,
                    Name = test.Category.Name
                },
                Questions = test.Questions.Select(question => new DalTestQuestion()
                {
                    Id = question.Id,
                    Text = question.Text,
                    AnswerOptions = question.AnswerOptions.Select(a => a.Text).ToList(),
                    CorrectAnswer = question.AnswerOptions.FirstOrDefault(a => a.IsCorrect).Text
                }).ToList()
            };
        }
        // Clear
        public void Update(DalTest entity)
        {
            Test test = context.Set<Test>().FirstOrDefault(t => t.Id == entity.Id);

            if (test != null)
            {
                test.Questions.Clear();
                test.CategoryId = entity.Category.Id;
                test.Title = entity.Title;
                test.Questions = entity.Questions.Select(question => new TestQuestion()
                {
                    Text = question.Text,
                    AnswerOptions = question.AnswerOptions.Select(answer => new AnswerOption()
                    { 
                        Text = answer,
                        IsCorrect = answer == question.CorrectAnswer ? true : false
                    }).ToList(),
                }).ToList();
            }
        }
    }
}
