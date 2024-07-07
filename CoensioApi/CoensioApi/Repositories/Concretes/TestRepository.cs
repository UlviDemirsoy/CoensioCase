using CoensioApi.Data;
using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CoensioApi.Repositories.Concretes
{
    public class TestRepository : ITestRepository, IDisposable
    {

        private readonly ApiDbContext _context;

        public TestRepository(ApiDbContext context)
        {
            _context= context;
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

        public void Add(Test test)
        {
            _context.Tests.Add(test);
            _context.SaveChanges();
        }

        public List<Test> GetTestsWithInclude()
        {
            var tests = _context.Tests
                .Include(x => x.FreeTextQuestions)
                .Include(x => x.MultipleChoiceQuestions)
                .Include(x => x.CodingQuestions)
                .ToList();

            return tests;
        }

        public Test GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            }

            try
            {
                return _context.Tests.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving CodingQuestion with id {id}.", ex);
            }
        }
    }
}
