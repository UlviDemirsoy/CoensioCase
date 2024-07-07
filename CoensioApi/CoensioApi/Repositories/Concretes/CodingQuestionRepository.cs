using CoensioApi.Data;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoensioApi.Repositories.Concretes
{
    public class CodingQuestionRepository : ICodingQuestionRepository, IDisposable
    {

        private readonly ApiDbContext _context;

        public CodingQuestionRepository(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(CodingQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.CodingQuestions.Add(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding CodingQuestion.", ex);
            }
        }

        public async Task AddAsync(CodingQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await _context.CodingQuestions.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding CodingQuestion asynchronously.", ex);
            }
        }

        public void Delete(CodingQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.CodingQuestions.Remove(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting CodingQuestion.", ex);
            }
        }

        public async Task<CodingQuestion> FindAsync(Expression<Func<CodingQuestion, bool>> lambda)
        {
            if (lambda == null)
            {
                throw new ArgumentNullException(nameof(lambda));
            }

            try
            {
                return await _context.CodingQuestions.FirstOrDefaultAsync(lambda);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while finding CodingQuestion asynchronously.", ex);
            }
        }

        public IEnumerable<CodingQuestion> GetAll()
        {
            try
            {
                return _context.CodingQuestions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving all CodingQuestions.", ex);
            }
        }

        public CodingQuestion GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            try
            {
                return _context.CodingQuestions.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving CodingQuestion with id {id}.", ex);
            }
        }

        public async Task<List<CodingQuestion>> ListAsync()
        {
            try
            {
                return await _context.CodingQuestions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving CodingQuestions asynchronously.", ex);
            }
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while saving changes.", ex);
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while saving changes asynchronously.", ex);
            }
        }

        public void Update(CodingQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.CodingQuestions.Update(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating CodingQuestion.", ex);
            }
        }

        public async Task UpdateAsync(CodingQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.CodingQuestions.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating CodingQuestion asynchronously.", ex);
            }
        }

        public async Task<List<CodingQuestion>> WhereAsync(Expression<Func<CodingQuestion, bool>> lambda)
        {
            if (lambda == null)
            {
                throw new ArgumentNullException(nameof(lambda));
            }

            try
            {
                return await _context.CodingQuestions.Where(lambda).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while querying CodingQuestions asynchronously.", ex);
            }
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<CodingQuestion> GetRandomByCount(int count)
        {
            return _context.CodingQuestions
                                      .OrderBy(x => EF.Functions.Random())
                                      .Take(count)
                                      .ToList();
        }
    }
}
