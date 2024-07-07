using CoensioApi.Data;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoensioApi.Repositories.Concretes
{
    public class AssignmentRepository : IAssignmentRepository ,IDisposable
    {
        private readonly ApiDbContext _dbContext;
        public AssignmentRepository(ApiDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public AssesmentAssignment GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            try
            {
                return _dbContext.AssesmentAssignments.Where(x=>x.isComleted != true && x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving AssesmentAssignment with id {id}.", ex);
            }
        }

        public void Update(AssesmentAssignment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _dbContext.AssesmentAssignments.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating AssesmentAssignment.", ex);
            }
        }

        public AssesmentAssignment Add(AssesmentAssignment assignment)
        {
            _dbContext.AssesmentAssignments.Add(assignment);
            _dbContext.SaveChanges();
            return(assignment);
        }

        public List<AssesmentAssignment> Where(Expression<Func<AssesmentAssignment, bool>> lambda)
        {
            return _dbContext.Set<AssesmentAssignment>().Include(x => x.Test)
                .ThenInclude(x => x.MultipleChoiceQuestions)
                .Include(x => x.Test)
                .ThenInclude(x => x.FreeTextQuestions)
                .Include(x => x.Test)
                .ThenInclude(x => x.CodingQuestions)
                .Where(lambda).ToList();
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
