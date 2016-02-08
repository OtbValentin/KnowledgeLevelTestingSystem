using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DbInitializer
{
    public class Initializer : DropCreateDatabaseAlways<QuizFrameworkContext>
    {
        protected override void Seed(QuizFrameworkContext context)
        {
            Role admin = new Role() { Name = "admin", Description = "Administrator of a site" };
            Role user = new Role() { Name = "user", Description = "Common user" };
            context.Roles.Add(admin);
            context.Roles.Add(user);
            IEnumerable<QuizQuestion> test1Questions = new QuizQuestion[] { new QuizQuestion() { Text = "The Capital of Great Britain is ...",
                AnswerOptions = new AnswerOption[] { new AnswerOption() { Text = "London", IsCorrect = true }, new AnswerOption() { Text = "Paris", IsCorrect = false }, new AnswerOption() { Text = "Minsk", IsCorrect = false } } },
            new QuizQuestion() { Text = "The largest country in the world ...",
                AnswerOptions = new AnswerOption[] { new AnswerOption() { Text = "Germany", IsCorrect = false }, new AnswerOption() { Text = "China", IsCorrect = false }, new AnswerOption() { Text = "Russia", IsCorrect = true } } },
            new QuizQuestion() { Text = "Prague is the capital of ...",
                AnswerOptions = new AnswerOption[] { new AnswerOption() { Text = "Czech Republic", IsCorrect = true }, new AnswerOption() { Text = "France", IsCorrect = false }, new AnswerOption() { Text = "Serbia", IsCorrect = false } } }};

            Quiz test1 = new Quiz() { Category = new QuizCategory() { Name = "Countries" }, Title = "The capitals of countries", Questions = new List<QuizQuestion>(test1Questions) };

            context.Tests.Add(test1);

            User newUser = new User() { Email = "gg@gmail.com", CreationDate = DateTime.Now, PasswordHash = "1234575" };
            newUser.Roles.Add(user);
            context.Users.Add(newUser);
            newUser = new User() { Email = "glhf@gmail.com", CreationDate = DateTime.Now, PasswordHash = "1234575" };
            newUser.Roles.Add(user);
            context.Users.Add(newUser);
            newUser = new User() { Email = "valikking@gmail.com", CreationDate = DateTime.Now, PasswordHash = "1234575" };
            newUser.Roles.Add(admin);
            newUser.Roles.Add(user);
            context.Users.Add(newUser);

            base.Seed(context);
        }
    }

    public static class DbInitializerLoader
    {
        public static void Load()
        {
            Database.SetInitializer(new Initializer());
        }

    }
}
