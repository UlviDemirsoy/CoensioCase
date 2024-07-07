using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using CoensioApi.Services.Abstracts;

namespace CoensioApi.Services.Concretes
{
    public class MultipleChoiceQuestionService : IMultipleChoiceQuestionService
    {
        private readonly IMultipleChoiceQuestionRepository _repo;
        public MultipleChoiceQuestionService(IMultipleChoiceQuestionRepository repo)
        {
            _repo = repo;
        }

        public void DeleteMultipleChoiceQuestionById(int id)
        {
            var question = _repo.GetById(id);
            if (question == null)
            {
                throw new KeyNotFoundException("Question not found");
            }

            _repo.Delete(question);
        }

        public List<MultipleChoiceQuestion> GetAllMultipleChoiceQuestions()
        {
            var questions = _repo.GetAll();
            return questions.ToList();
        }

        public MultipleChoiceQuestion GetMultipleChoiceQuestionById(int id)
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

            return question;
        }

        public MultipleChoiceQuestion InsertMultipleChoiceQuestion(dtoCreateMultipleChoiceQuestion question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question), "Question is null");
            }

            var newQuestion = new MultipleChoiceQuestion
            {
                QuestionText = question.QuestionText,
                TrueAnswer = question.TrueAnswer,
                Options = question.Options,
            };

            _repo.Add(newQuestion);

            return newQuestion;
        }

        public MultipleChoiceQuestion UpdateMultipleChoiceQuestionById(int id, dtoUpdateMultipleChoiceQuestion question)
        {
            var existingQuestion = _repo.GetById(id);
            if (existingQuestion == null)
            {
                throw new KeyNotFoundException("Question Not Found");
            }

            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.Options = question.Options;
            existingQuestion.TrueAnswer = question.TrueAnswer;

            _repo.Update(existingQuestion);

            return (existingQuestion);

        }
    }
}
