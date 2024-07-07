using System.ComponentModel.DataAnnotations;

namespace CoensioApi.Data.Models
{
    public class FreeTextQuestionTestTakerAnswer
    {
        [Key]
        public int Id { get; set; }
        public AssesmentAssignment AssesmentAssignment { get; set; }
        public FreeTextQuestion FreeTextQuestion { get; set; }
        public string UserSubmission { get; set; }
    }
}
