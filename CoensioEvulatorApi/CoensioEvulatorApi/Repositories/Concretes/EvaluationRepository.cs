using CoensioEvulatorApi.Data;
using CoensioEvulatorApi.Data.Dtos;
using CoensioEvulatorApi.Data.Models;
using CoensioEvulatorApi.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoensioEvulatorApi.Repositories.Concretes
{
    public class EvaluationRepository : IEvaluationRepository, IDisposable
    {
        private readonly ApiDbContext _dbContext;
        public EvaluationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Evaluate(int id)
        {
            var submisison = _dbContext.Set<AssesmentAssignment>().Include(x => x.Test)
                .ThenInclude(x => x.MultipleChoiceQuestions)
                .ThenInclude(x=> x.MultipleChoiceQuestionTestTakerAnswers)
                .Include(x => x.Test)
                .ThenInclude(x => x.FreeTextQuestions)
                .ThenInclude(x => x.FreeTextQuestionTestTakerAnswers)

                .Include(x => x.Test)
                .ThenInclude(x => x.CodingQuestions)
                .ThenInclude(x => x.CodingQuestionTestTakerAnswers)

                .FirstOrDefault(x=>x.Id == id);

            //todos

            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            submisison.Result = randomNumber;

            _dbContext.AssesmentAssignments.Update(submisison);
            _dbContext.SaveChanges();

        }

        public List<dtoEvaluationList> GetEvaluations()
        {
            var query = _dbContext.AssesmentAssignments
                 .Include(a => a.Test) 
                 .Where(a => a.isComleted) 
                 .OrderBy(a => a.Test.Name) 
                 .ThenBy(a => a.Result) 
                 .Select(a => new dtoEvaluationList
                 {
                     TestName = a.Test.Name,
                     Result = a.Result,
                     Name = a.UserEmail,
                 }).ToList();

            return query;
        }


        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
