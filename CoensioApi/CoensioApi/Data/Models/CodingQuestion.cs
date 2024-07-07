using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoensioApi.Data.Models
{
    public class CodingQuestion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CodeTemplate { get; set; }
        [Required]
        public string Input { get; set; }
        [Required]
        public string Output { get; set; }
        public ICollection<Test> Tests { get; set; } 
        public ICollection<CodingQuestionsTestTakerAnswer> CodingQuestionTestTakerAnswers { get; set; } 
    }
}
