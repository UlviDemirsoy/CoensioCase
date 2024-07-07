using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;

namespace CoensioApi.Services.Abstracts
{
    public interface ICodingQuestionService
    {
        CodingQuestion UpdateCodingQuestionById(int id, dtoUpdateCodingQuestion codingQuestion);
        void DeleteCodingQuestionById(int id);
        dtoListCodingQuestion GetCodingQuestionById(int id);
        CodingQuestion InsertCodingQuestion(dtoCreateCodingQuestion newCodingQuestion);
        List<dtoListCodingQuestion> GetAllCodingQuestions();
    }
}
