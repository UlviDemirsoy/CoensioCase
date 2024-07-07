using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoensioEvulatorApi.Data.Models
{
    public class CodingQuestion
    {
        [Key]
        public int Id { get; set; }
        public string CodeTemplate { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public ICollection<Test> Tests { get; set; } 
        public ICollection<CodingQuestionsTestTakerAnswer> CodingQuestionTestTakerAnswers { get; set; } 
    }
}
