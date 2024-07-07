using CoensioApi.Data.Models;

namespace CoensioApi.Repositories.Abstracts
{
    public interface IFreeTextQuestionTestTakerAnswerRepository
    {
        void Add(FreeTextQuestionTestTakerAnswer model);
        List<FreeTextQuestionTestTakerAnswer> GetByAssesmentId(int id);
    }
}
