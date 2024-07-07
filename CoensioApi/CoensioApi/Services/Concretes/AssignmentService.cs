using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using CoensioApi.Services.Abstracts;
using System.Xml;

namespace CoensioApi.Services.Concretes
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IUserService _userService;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly ITestRepository _testRespository;
        private readonly ICodingQuestionTestTakerAnswerRepository _codingQuestionTestTakerAnswerRepository;
        private readonly IFreeTextQuestionTestTakerAnswerRepository _freeTextQuestionTestTakerAnswerRepository;
        private readonly IMultipleChoiceQuestionTestTakerAnswerRepository _multipleChoiceQuestionTestTakerAnswerRepository;
        private readonly ICodingQuestionRepository _codingQuestionRepository;
        private readonly IFreeTextQuestionRepository _freeTextQuestionRepository;
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        private readonly IMessageProducer _messageProducer;

        public AssignmentService(IUserService userService,
            IAssignmentRepository assignmentRepository,
            ITestRepository testRespository,
            ICodingQuestionTestTakerAnswerRepository codingQuestionTestTakerAnswerRepository,
            IFreeTextQuestionTestTakerAnswerRepository freeTextQuestionTestTakerAnswerRepository,
            IMultipleChoiceQuestionTestTakerAnswerRepository multipleChoiceQuestionTestTakerAnswerRepository,
            IFreeTextQuestionRepository freeTextQuestionRepository,
            IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository,
            ICodingQuestionRepository codingQuestionRepository,
            IMessageProducer messageProducer)
        {
            _userService = userService;
            _assignmentRepository = assignmentRepository;
            _testRespository = testRespository;
            _codingQuestionTestTakerAnswerRepository = codingQuestionTestTakerAnswerRepository;
            _freeTextQuestionTestTakerAnswerRepository = freeTextQuestionTestTakerAnswerRepository;
            _multipleChoiceQuestionTestTakerAnswerRepository = multipleChoiceQuestionTestTakerAnswerRepository;
            _freeTextQuestionRepository = freeTextQuestionRepository;
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
            _codingQuestionRepository = codingQuestionRepository;
            _messageProducer = messageProducer;
        }

        public void CreateSubmission(dtoCreateSubmission dto)
        {
            var assignment = _assignmentRepository.GetById(dto.AssignmentId);

            if (assignment == null)
            {
                throw new KeyNotFoundException("Assignment not found");
            }

            assignment.isComleted = true;
            assignment.FreeTextQuestionTestTakerAnswers = new List<FreeTextQuestionTestTakerAnswer>
            {
                new FreeTextQuestionTestTakerAnswer
                {
                   AssesmentAssignment= assignment,
                   FreeTextQuestion = _freeTextQuestionRepository.GetById(dto.FreeTextQuestionId1),
                   UserSubmission = dto.FreeTextQuesitonUserSubmission1
                },
                new FreeTextQuestionTestTakerAnswer
                {
                    AssesmentAssignment= assignment,
                   FreeTextQuestion = _freeTextQuestionRepository.GetById(dto.FreeTextQuestionId2),
                   UserSubmission = dto.FreeTextQuesitonUserSubmission2
                }
            };
            assignment.MultipleChoiceQuestionTestTakerAnswers = new List<MultipleChoiceQuestionTestTakerAnswer>
            {
                new MultipleChoiceQuestionTestTakerAnswer
                {
                   AssesmentAssignment= assignment,
                   MultipleChoiceQuestion = _multipleChoiceQuestionRepository.GetById(dto.MultipleChoiceQuestionId1),
                   UserSubmission = dto.MultipleChoiceQuesitonUserSubmission1
                },
                new MultipleChoiceQuestionTestTakerAnswer
                {
                   AssesmentAssignment= assignment,
                   MultipleChoiceQuestion = _multipleChoiceQuestionRepository.GetById(dto.MultipleChoiceQuestionId2),
                   UserSubmission = dto.MultipleChoiceQuesitonUserSubmission2
                }
            };
            assignment.CodingQuestionsTestTakerAnswers = new List<CodingQuestionsTestTakerAnswer>
            {
                new CodingQuestionsTestTakerAnswer
                {
                   AssesmentAssignment= assignment,
                   CodingQuestion = _codingQuestionRepository.GetById(dto.CodingQuestionId),
                   UserSubmission = dto.CodingQuesitonUserSubmission
                }
            };

            _assignmentRepository.Update(assignment);

            //SendingMessage to evalutaor API
            dtoMessageBusEvent message = new dtoMessageBusEvent();
            message.AssignmentId = assignment.Id;
            message.Event = "submission";
            _messageProducer.PublishMessage(message);

        }

        public AssesmentAssignment CreateTestAssignment(dtoCreateTestAssignment dto)
        {
            AssesmentAssignment assignment = new AssesmentAssignment();
            Test testtoassign = _testRespository.GetById(dto.TestId);
            if (testtoassign == null)
                throw new KeyNotFoundException("Test not found");
            assignment.Test = testtoassign;
            assignment.UserEmail = dto.Email;
            _assignmentRepository.Add(assignment);

            return assignment;
        }

        public List<AssesmentAssignment> GetCurrentUserAssignments()
        {
            var currUserEmail = _userService.GetCurrentUserEmail();
            var list = _assignmentRepository.Where(x => x.UserEmail == currUserEmail);

            return list;
        }
    }
}
