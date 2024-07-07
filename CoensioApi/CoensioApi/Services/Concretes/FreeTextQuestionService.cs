using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using CoensioApi.Services.Abstracts;

namespace CoensioApi.Services.Concretes
{
    public class FreeTextQuestionService : IFreeTextQuestionService
    {
        private readonly IFreeTextQuestionRepository _repo;

        public FreeTextQuestionService(IFreeTextQuestionRepository repo)
        {
            _repo = repo;
        }

        public void DeleteFreeTextQuestionById(int id)
        {
            var question = _repo.GetById(id);
            if (question == null)
            {
                throw new KeyNotFoundException("Question not found");
            }

            _repo.Delete(question);
        }

        public List<dtoListFreeTextQuestion> GetAllFreeTextQuestions()
        {
            var questions = _repo.GetAll();

            List<dtoListFreeTextQuestion> list = new List<dtoListFreeTextQuestion>();

            foreach (FreeTextQuestion question in questions)
            {
                list.Add(new dtoListFreeTextQuestion
                {
                    QuestionText = question.QuestionText,
                    TrueAnswerText = question.TrueAnswerText,
                    Id = question.Id,
                });
            }

            return list;
        }

        public dtoListFreeTextQuestion GetFreeTextQuestionById(int id)
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
            dtoListFreeTextQuestion dto = new dtoListFreeTextQuestion
            {
                QuestionText = question.QuestionText,
                TrueAnswerText = question.TrueAnswerText,
                Id = question.Id,
            };


            return dto;
        }

        public FreeTextQuestion InsertFreeTextQuestion(dtoCreateFreeTextQuestion question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question), "Question is null");
            }

            var newQuestion = new FreeTextQuestion
            {
                QuestionText = question.QuestionText,
                TrueAnswerText = question.TrueAnswerText
            };

            _repo.Add(newQuestion);

            return newQuestion;
        }

        public FreeTextQuestion UpdateFreeTextQuestionById(int id, dtoUpdateFreeTextQuestion question)
        {
            var existingQuestion = _repo.GetById(id);
            if (existingQuestion == null)
            {
                throw new KeyNotFoundException("Question Not Found");
            }

            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.TrueAnswerText = question.TrueAnswerText;

            _repo.Update(existingQuestion);

            return (existingQuestion);

        }
    }
}
