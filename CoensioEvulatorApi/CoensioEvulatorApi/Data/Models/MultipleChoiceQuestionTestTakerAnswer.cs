using System.ComponentModel.DataAnnotations;

namespace CoensioEvulatorApi.Data.Models
{
    public class MultipleChoiceQuestionTestTakerAnswer
    {
        [Key]
        public int Id { get; set; }
        public AssesmentAssignment AssesmentAssignment { get; set; }

        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
        public string UserSubmission { get; set; }
    }
}
