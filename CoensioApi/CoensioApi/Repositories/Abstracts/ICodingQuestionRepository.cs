using CoensioApi.Data.Models;

namespace CoensioApi.Repositories.Abstracts
{
    public interface ICodingQuestionRepository : IRepository<CodingQuestion>
    {
        List<CodingQuestion> GetRandomByCount(int count);
    }
}
