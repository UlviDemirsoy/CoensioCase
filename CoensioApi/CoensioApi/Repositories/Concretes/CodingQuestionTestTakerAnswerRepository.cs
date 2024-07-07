using CoensioApi.Data;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CoensioApi.Repositories.Concretes
{
    public class CodingQuestionTestTakerAnswerRepository : ICodingQuestionTestTakerAnswerRepository
    {

        private readonly ApiDbContext _context;
        public CodingQuestionTestTakerAnswerRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void Add(CodingQuestionsTestTakerAnswer model)
        {
            _context.CodingQuestionsTestTakerAnswers.Add(model);
            _context.SaveChanges();
        }

        public List<CodingQuestionsTestTakerAnswer> GetByAssesmentId(int id)
        {
            var q = _context.CodingQuestionsTestTakerAnswers
                .Include(x => x.AssesmentAssignment)
                .Where(x => x.Id == id).ToList();

            return q;
        }
    }
}
