using CoensioApi.Data.Models;

namespace CoensioApi.Repositories.Abstracts
{
    public interface IMultipleChoiceQuestionRepository : IRepository<MultipleChoiceQuestion>
    {
        List<MultipleChoiceQuestion> GetRandomByCount(int count);

    }
}
