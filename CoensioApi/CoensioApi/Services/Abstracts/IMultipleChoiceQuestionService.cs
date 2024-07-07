using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;

namespace CoensioApi.Services.Abstracts
{
    public interface IMultipleChoiceQuestionService
    {
        MultipleChoiceQuestion UpdateMultipleChoiceQuestionById(int id, dtoUpdateMultipleChoiceQuestion codingQuestion);
        void DeleteMultipleChoiceQuestionById(int id);
        dtoListMultipleChoiceQuestion GetMultipleChoiceQuestionById(int id);
        MultipleChoiceQuestion InsertMultipleChoiceQuestion(dtoCreateMultipleChoiceQuestion newMultipleChoiceQuestion);
        List<dtoListMultipleChoiceQuestion> GetAllMultipleChoiceQuestions();
    }
}
