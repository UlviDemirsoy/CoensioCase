using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using CoensioApi.Repositories.Concretes;
using CoensioApi.Services.Abstracts;

namespace CoensioApi.Services.Concretes
{
    public class CodingQuestionService : ICodingQuestionService
    {

        private readonly ICodingQuestionRepository _repo;
        public CodingQuestionService(ICodingQuestionRepository repo)
        {
            _repo = repo;
        }

        public void DeleteCodingQuestionById(int id)
        {
            var question = _repo.GetById(id);
            if (question == null)
            {
                throw new ArgumentException("Question not found");
            }

            _repo.Delete(question);
        }

        public List<dtoListCodingQuestion> GetAllCodingQuestions()
        {
            var questions = _repo.GetAll();

            List<dtoListCodingQuestion> list = new List<dtoListCodingQuestion>();

            foreach (CodingQuestion question in questions)
            {
                list.Add(new dtoListCodingQuestion
                {
                    CodeTemplate = question.CodeTemplate,
                    Id = question.Id,
                    Input = question.Input,
                    Output = question.Output
                });
            }
            return list.ToList();
        }

        public dtoListCodingQuestion GetCodingQuestionById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid question ID");
            }

            var question = _repo.GetById(id);
            if (question == null)
            {
                throw new KeyNotFoundException("Question not found");
            }
            dtoListCodingQuestion dto = new dtoListCodingQuestion{
                CodeTemplate = question.CodeTemplate,
                Id = question.Id,
                Input = question.Input,
                Output = question.Output
            };

            return dto;
        }

        public CodingQuestion InsertCodingQuestion(dtoCreateCodingQuestion question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question), "Question is null");
            }

            var newQuestion = new CodingQuestion
            {
                CodeTemplate = question.CodeTemplate,
                Input = question.Input,
                Output = question.Output
            };

            _repo.Add(newQuestion);

            return newQuestion;
        }

        public CodingQuestion UpdateCodingQuestionById(int id, dtoUpdateCodingQuestion codingQuestion)
        {
            var existingQuestion = _repo.GetById(id);
            if (existingQuestion == null)
            {
                throw new KeyNotFoundException("Question Not Found");
            }

            existingQuestion.CodeTemplate = codingQuestion.CodeTemplate;
            existingQuestion.Input = codingQuestion.Input;
            existingQuestion.Output = codingQuestion.Output;

            _repo.Update(existingQuestion);

            return(existingQuestion);
        }
    }
}
