using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;

namespace CoensioApi.Services.Abstracts
{
    public interface ITestService
    {
        Test GenerateTest(dtoCreateTest dtoTest);
        List<Test> ListTests();
    }
}
