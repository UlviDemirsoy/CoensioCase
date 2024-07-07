using System.ComponentModel.DataAnnotations;

namespace CoensioApi.Data.Models
{
    public class CodingQuestionsTestTakerAnswer
    {
        [Key]
        public int Id { get; set; }
        public AssesmentAssignment AssesmentAssignment { get; set; }
        public CodingQuestion CodingQuestion { get; set; }
        public string UserSubmission { get; set; }


    }
}
