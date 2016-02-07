using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DbInitializer
{
    public class Initializer : DropCreateDatabaseAlways<TestingSystemContext>
    {
        protected override void Seed(TestingSystemContext context)
        {
            Role admin = new Role() { Name = "admin", Description = "Administrator of a site" };
            Role user = new Role() { Name = "user", Description = "Common user" };
            context.Roles.Add(admin);
            context.Roles.Add(user);
            IEnumerable<TestQuestion> test1Questions = new TestQuestion[] { new TestQuestion() { Text = "The Capital of Greate Britains is ...",
                AnswerOptions = new AnswerOption[] { new AnswerOption() { Text = "London", IsCorrect = true }, new AnswerOption() { Text = "Paris", IsCorrect = false }, new AnswerOption() { Text = "Minsk", IsCorrect = false } } },
            new TestQuestion() { Text = "The largest country in the world ...",
                AnswerOptions = new AnswerOption[] { new AnswerOption() { Text = "Germany", IsCorrect = false }, new AnswerOption() { Text = "China", IsCorrect = false }, new AnswerOption() { Text = "Russia", IsCorrect = true } } },
            new TestQuestion() { Text = "Prague is the capital of ...",
                AnswerOptions = new AnswerOption[] { new AnswerOption() { Text = "Czech Republic", IsCorrect = true }, new AnswerOption() { Text = "France", IsCorrect = false }, new AnswerOption() { Text = "Serbia", IsCorrect = false } } }};

            Test test1 = new Test() { Category = new TestCategory() { Name = "Countries" }, Title = "The capitals of countries", Questions = new List<TestQuestion>(test1Questions) };

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
