using CoensioApi.Data.Models;

namespace CoensioApi.Repositories.Abstracts
{
    public interface ICodingQuestionTestTakerAnswerRepository
    {
        void Add(CodingQuestionsTestTakerAnswer model);
        List<CodingQuestionsTestTakerAnswer> GetByAssesmentId(int id);
    }
}
