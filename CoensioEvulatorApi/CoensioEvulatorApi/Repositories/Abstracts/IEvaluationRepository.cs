using CoensioEvulatorApi.Data.Dtos;
using CoensioEvulatorApi.Data.Models;

namespace CoensioEvulatorApi.Repositories.Abstracts
{
    public interface IEvaluationRepository
    {
        List<dtoEvaluationList> GetEvaluations();
        void Evaluate(int id);
    }
}
