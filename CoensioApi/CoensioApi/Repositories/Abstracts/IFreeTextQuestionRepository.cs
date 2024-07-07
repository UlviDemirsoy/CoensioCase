using CoensioApi.Data.Models;

namespace CoensioApi.Repositories.Abstracts
{
    public interface IFreeTextQuestionRepository : IRepository<FreeTextQuestion>
    {
        List<FreeTextQuestion> GetRandomByCount(int count);

    }
}
