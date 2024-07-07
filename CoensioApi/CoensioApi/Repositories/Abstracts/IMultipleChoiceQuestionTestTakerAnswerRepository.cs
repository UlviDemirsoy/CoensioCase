using CoensioApi.Data.Models;

namespace CoensioApi.Repositories.Abstracts
{
    public interface IMultipleChoiceQuestionTestTakerAnswerRepository
    {
        void Add(MultipleChoiceQuestionTestTakerAnswer model);
        List<MultipleChoiceQuestionTestTakerAnswer> GetByAssesmentId(int id);
    }
}
