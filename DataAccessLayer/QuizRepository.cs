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
    public class QuizRepository : IQuizRepository
    {
        private readonly DbContext context;

        public QuizRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalQuiz entity)
        {
            Quiz test = new Quiz() { Title = entity.Title, CategoryId = entity.Category.Id };

            test.Questions = entity.Questions.Select(question => new QuizQuestion()
            {
                Text = question.Text,
                AnswerOptions = question.AnswerOptions.Select(answer => new AnswerOption()
                {
                    Text = answer,
                    IsCorrect = answer == question.CorrectAnswer ? true : false
                }).ToList()
            }).ToList();

            context.Set<Quiz>().Add(test);
        }

        public void Delete(int id)
        {
            Quiz test = context.Set<Quiz>().FirstOrDefault(t => t.Id == id);

            if (test != null)
            {
                context.Set<Quiz>().Remove(test);
            }
        }

        public IEnumerable<DalQuiz> GetAll()
        {
            return context.Set<Quiz>().Select(test => new DalQuiz()
            {
                Id = test.Id,
                Title = test.Title,
                Category = new DalQuizCategory()
                {
                    Id = test.Category.Id,
                    Name = test.Category.Name
                },
                Questions = test.Questions.Select(question => new DalQuizQuestion()
                {
                    Id = question.Id,
                    Text = question.Text,
                    AnswerOptions = question.AnswerOptions.Select(a => a.Text).ToList(),
                    CorrectAnswer = question.AnswerOptions.FirstOrDefault(a => a.IsCorrect).Text
                }).ToList()
            });
        }

        public DalQuiz GetById(int id)
        {
            Quiz test = context.Set<Quiz>().FirstOrDefault(t => t.Id == id);

            if (test == null)
            {
                return null;
            }

            return new DalQuiz()
            {
                Id = test.Id,
                Title = test.Title,
                Category = new DalQuizCategory()
                {
                    Id = test.Category.Id,
                    Name = test.Category.Name
                },
                Questions = test.Questions.Select(question => new DalQuizQuestion()
                {
                    Id = question.Id,
                    Text = question.Text,
                    AnswerOptions = question.AnswerOptions.Select(a => a.Text).ToList(),
                    CorrectAnswer = question.AnswerOptions.FirstOrDefault(a => a.IsCorrect).Text
                }).ToList()
            };
        }
        // Clear
        public void Update(DalQuiz entity)
        {
            Quiz test = context.Set<Quiz>().FirstOrDefault(t => t.Id == entity.Id);

            if (test != null)
            {
                test.Questions.Clear();
                test.CategoryId = entity.Category.Id;
                test.Title = entity.Title;
                test.Questions = entity.Questions.Select(question => new QuizQuestion()
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
