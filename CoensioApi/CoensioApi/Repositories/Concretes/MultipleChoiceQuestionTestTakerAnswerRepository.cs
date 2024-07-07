using CoensioApi.Data;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CoensioApi.Repositories.Concretes
{
    public class MultipleChoiceQuestionTestTakerAnswerRepository : IMultipleChoiceQuestionTestTakerAnswerRepository
    {

        private readonly ApiDbContext _context;
        public MultipleChoiceQuestionTestTakerAnswerRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void Add(MultipleChoiceQuestionTestTakerAnswer model)
        {

            _context.MultipleChoiceQuestionTestTakerAnswers.Add(model);
            _context.SaveChanges();
        }

        public List<MultipleChoiceQuestionTestTakerAnswer> GetByAssesmentId(int id)
        {
            var q = _context.MultipleChoiceQuestionTestTakerAnswers
                .Include(x=>x.AssesmentAssignment)
                .Where(x=>x.Id == id).ToList();

            return q;
        }
    }
}
