using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;

namespace CoensioApi.Repositories.Abstracts
{
    public interface ITestRepository
    {
        void Add(Test test);
        List<Test> GetTestsWithInclude();
        Test GetById(int id);
    }
}
