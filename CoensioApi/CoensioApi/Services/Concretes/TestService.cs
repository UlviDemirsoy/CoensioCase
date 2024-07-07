using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using CoensioApi.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CoensioApi.Services.Concretes
{
    public class TestService : ITestService
    {

        private readonly ICodingQuestionRepository _codingQuestionRepository;
        private readonly IFreeTextQuestionRepository _freeTextQuestionRepository;
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        private readonly ITestRepository _testReporsitory;

        public TestService(ICodingQuestionRepository codingQuestionRepository
            , IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository
            , IFreeTextQuestionRepository freeTextQuestionRepository
            , ITestRepository testReporsitory
        ){
            _codingQuestionRepository= codingQuestionRepository;
            _freeTextQuestionRepository= freeTextQuestionRepository;
            _multipleChoiceQuestionRepository= multipleChoiceQuestionRepository;
            _testReporsitory= testReporsitory;
        }


        public Test GenerateTest(dtoCreateTest dtoTest)
        {
            var randomCodingQuestions = _codingQuestionRepository.GetRandomByCount(1);

            var randomFreeTextQuestions = _freeTextQuestionRepository.GetRandomByCount(2);

            var randomMultipleChoilceQuestions = _multipleChoiceQuestionRepository.GetRandomByCount(2);
            Test test = new Test{
                Name = dtoTest.Name,
                CodingQuestions = randomCodingQuestions,
                MultipleChoiceQuestions = randomMultipleChoilceQuestions,
                FreeTextQuestions = randomFreeTextQuestions
            };
            _testReporsitory.Add(test);

            return test;
        }

        public List<Test> ListTests()
        {
            return _testReporsitory.GetTestsWithInclude();
        }
    }
}
