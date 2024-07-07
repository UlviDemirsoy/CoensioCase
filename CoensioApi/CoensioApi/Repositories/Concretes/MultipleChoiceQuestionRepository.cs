using CoensioApi.Data;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using CoensioApi.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoensioApi.Repositories.Concretes
{
    public class MultipleChoiceQuestionRepository : IMultipleChoiceQuestionRepository, IDisposable
    {
        private readonly ApiDbContext _context;

        public MultipleChoiceQuestionRepository(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(MultipleChoiceQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.MultipleChoiceQuestions.Add(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding MultipleChoiceQuestion.", ex);
            }
        }

        public async Task AddAsync(MultipleChoiceQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await _context.MultipleChoiceQuestions.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding MultipleChoiceQuestion asynchronously.", ex);
            }
        }

        public void Delete(MultipleChoiceQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.MultipleChoiceQuestions.Remove(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting MultipleChoiceQuestion.", ex);
            }
        }

        public async Task<MultipleChoiceQuestion> FindAsync(Expression<Func<MultipleChoiceQuestion, bool>> lambda)
        {
            if (lambda == null)
            {
                throw new ArgumentNullException(nameof(lambda));
            }

            try
            {
                return await _context.MultipleChoiceQuestions.FirstOrDefaultAsync(lambda);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while finding MultipleChoiceQuestion asynchronously.", ex);
            }
        }

        public IEnumerable<MultipleChoiceQuestion> GetAll()
        {
            try
            {
                return _context.MultipleChoiceQuestions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving all MultipleChoiceQuestions.", ex);
            }
        }

        public MultipleChoiceQuestion GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            try
            {
                return _context.MultipleChoiceQuestions.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving MultipleChoiceQuestion with id {id}.", ex);
            }
        }

        public async Task<List<MultipleChoiceQuestion>> ListAsync()
        {
            try
            {
                return await _context.MultipleChoiceQuestions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving MultipleChoiceQuestions asynchronously.", ex);
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

        public void Update(MultipleChoiceQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.MultipleChoiceQuestions.Update(entity);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating MultipleChoiceQuestion.", ex);
            }
        }

        public async Task UpdateAsync(MultipleChoiceQuestion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.MultipleChoiceQuestions.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating MultipleChoiceQuestion asynchronously.", ex);
            }
        }

        public async Task<List<MultipleChoiceQuestion>> WhereAsync(Expression<Func<MultipleChoiceQuestion, bool>> lambda)
        {
            if (lambda == null)
            {
                throw new ArgumentNullException(nameof(lambda));
            }

            try
            {
                return await _context.MultipleChoiceQuestions.Where(lambda).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while querying MultipleChoiceQuestions asynchronously.", ex);
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

        public List<MultipleChoiceQuestion> GetRandomByCount(int count)
        {
            return _context.MultipleChoiceQuestions
                                      .OrderBy(x => EF.Functions.Random())
                                      .Take(count)
                                      .ToList();
        }
    }
}
