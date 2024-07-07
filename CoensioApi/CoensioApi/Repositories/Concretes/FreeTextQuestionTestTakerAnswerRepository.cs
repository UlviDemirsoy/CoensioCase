using CoensioApi.Data;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CoensioApi.Repositories.Concretes
{
    public class FreeTextQuestionTestTakerAnswerRepository : IFreeTextQuestionTestTakerAnswerRepository
    {

        private readonly ApiDbContext _context;
        public FreeTextQuestionTestTakerAnswerRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void Add(FreeTextQuestionTestTakerAnswer model)
        {
            _context.FreeTextQuestionTestTakerAnswers.Add(model);
            _context.SaveChanges();
        }

        public List<FreeTextQuestionTestTakerAnswer> GetByAssesmentId(int id)
        {
            var q = _context.FreeTextQuestionTestTakerAnswers
                .Include(x => x.AssesmentAssignment)
                .Where(x => x.Id == id).ToList();

            return q;
        }
    }
}
