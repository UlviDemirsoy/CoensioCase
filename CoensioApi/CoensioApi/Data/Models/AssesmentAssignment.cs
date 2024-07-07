using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoensioApi.Data.Models
{
    public class AssesmentAssignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public Test Test { get; set; }
        public bool isComleted { get; set; } = false;
        public int? Result { get; set; }
        public ICollection<FreeTextQuestionTestTakerAnswer> FreeTextQuestionTestTakerAnswers { get; set; }
        public ICollection<MultipleChoiceQuestionTestTakerAnswer> MultipleChoiceQuestionTestTakerAnswers { get; set; }
        public ICollection<CodingQuestionsTestTakerAnswer> CodingQuestionsTestTakerAnswers { get; set; }
  
    }
}
