using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;

namespace CoensioApi.Services.Abstracts
{
    public interface IFreeTextQuestionService
    {
        FreeTextQuestion UpdateFreeTextQuestionById(int id, dtoUpdateFreeTextQuestion question);
        void DeleteFreeTextQuestionById(int id);
        dtoListFreeTextQuestion GetFreeTextQuestionById(int id);
        FreeTextQuestion InsertFreeTextQuestion(dtoCreateFreeTextQuestion question);
        List<dtoListFreeTextQuestion> GetAllFreeTextQuestions();
    }
}
