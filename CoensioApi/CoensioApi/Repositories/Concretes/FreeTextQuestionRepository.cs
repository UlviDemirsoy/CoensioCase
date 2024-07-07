using CoensioApi.Data;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoensioApi.Repositories.Concretes
{
    public class FreeTextQuestionRepository : IFreeTextQuestionRepository, IDisposable
    {
        private readonly ApiDbContext _context;

        public FreeTextQuestionRepository(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Data.Models.FreeTextQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.FreeTextQuestions.Add(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding FreeTextQuestion.", ex);
            }
        }

        public async Task AddAsync(Data.Models.FreeTextQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await _context.FreeTextQuestions.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding FreeTextQuestion asynchronously.", ex);
            }
        }

        public void Delete(Data.Models.FreeTextQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.FreeTextQuestions.Remove(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting FreeTextQuestion.", ex);
            }
        }

        public async Task<Data.Models.FreeTextQuestion> FindAsync(Expression<Func<Data.Models.FreeTextQuestion, bool>> lambda)
        {
            if (lambda == null)
            {
                throw new ArgumentNullException(nameof(lambda));
            }

            try
            {
                return await _context.FreeTextQuestions.FirstOrDefaultAsync(lambda);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while finding FreeTextQuestion asynchronously.", ex);
            }
        }

        public IEnumerable<Data.Models.FreeTextQuestion> GetAll()
        {
            try
            {
                return _context.FreeTextQuestions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving all FreeTextQuestions.", ex);
            }
        }

        public Data.Models.FreeTextQuestion GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            try
            {
                return _context.FreeTextQuestions.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving FreeTextQuestion with id {id}.", ex);
            }
        }

        public async Task<List<Data.Models.FreeTextQuestion>> ListAsync()
        {
            try
            {
                return await _context.FreeTextQuestions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving FreeTextQuestions asynchronously.", ex);
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

        public void Update(Data.Models.FreeTextQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.FreeTextQuestions.Update(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating FreeTextQuestion.", ex);
            }
        }

        public async Task UpdateAsync(Data.Models.FreeTextQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.FreeTextQuestions.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating FreeTextQuestion asynchronously.", ex);
            }
        }

        public async Task<List<Data.Models.FreeTextQuestion>> WhereAsync(Expression<Func<Data.Models.FreeTextQuestion, bool>> lambda)
        {
            if (lambda == null)
            {
                throw new ArgumentNullException(nameof(lambda));
            }

            try
            {
                return await _context.FreeTextQuestions.Where(lambda).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while querying FreeTextQuestions asynchronously.", ex);
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

        public List<FreeTextQuestion> GetRandomByCount(int count)
        {
            return _context.FreeTextQuestions
                                     .OrderBy(x => EF.Functions.Random())
                                     .Take(count)
                                     .ToList();
        }
    }
}
