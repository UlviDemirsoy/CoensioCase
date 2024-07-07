using CoensioApi.Data;
using CoensioApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoensioAPI.Extensions
{
    public static class ApplyMigrations
    {
        public static void Migrate(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApiDbContext dbContext = scope.ServiceProvider.GetService<ApiDbContext>();

            dbContext.Database.Migrate();
            if (dbContext.Admins.Count() == 0)
            {
                dbContext.Admins.AddRange(
                    new List<AdminUser>() {
                         new AdminUser() { Email="ulvidemirsoy@gmail.com"},
                    }
                    );
            }


            if (dbContext.CodingQuestions.Count() == 0)
            {
                dbContext.CodingQuestions.AddRange(
                    new List<CodingQuestion>() {
                         new CodingQuestion() { CodeTemplate = "quicksort", Input="test", Output="test" },
                         new CodingQuestion() { CodeTemplate = "matching paranthesis", Input="test2", Output="test3" },
                         new CodingQuestion() { CodeTemplate = "graph traversal", Input="test2", Output="test3" }
                        }
                    );
            }

            if (dbContext.FreeTextQuestions.Count() == 0)
            {
                dbContext.FreeTextQuestions.AddRange(
                    new List<FreeTextQuestion>() {
                         new FreeTextQuestion() { QuestionText = "what is dependency injection",  TrueAnswerText="test"},
                         new FreeTextQuestion() { QuestionText = "multithreading vs multiprocessing", TrueAnswerText="test2" },
                         new FreeTextQuestion() { QuestionText = "describe process states in operating system", TrueAnswerText="test2" }
                        }
                    );
            }

            if (dbContext.MultipleChoiceQuestions.Count() == 0)
            {
                dbContext.MultipleChoiceQuestions.AddRange(
                    new List<MultipleChoiceQuestion>() {
                         new MultipleChoiceQuestion() {  QuestionText = "select dependency injection types", Options="test0;test1;test2", TrueAnswer="test0" },
                         new MultipleChoiceQuestion() { QuestionText = "select faster algorithm", Options="test0;test1;test2", TrueAnswer="test1" },
                         new MultipleChoiceQuestion() { QuestionText = "what is the output of the code below", Options="test0;test1;test2", TrueAnswer="test2" }
                        }
                    );
            }


            dbContext.SaveChanges();
        }
    }
}
