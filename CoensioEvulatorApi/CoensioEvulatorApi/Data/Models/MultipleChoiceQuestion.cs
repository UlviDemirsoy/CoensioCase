using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoensioEvulatorApi.Data.Models
{
    public class MultipleChoiceQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Options { get; set; }
        public string TrueAnswer { get; set; }
        public ICollection<Test> Tests { get; set; } 
        public ICollection<MultipleChoiceQuestionTestTakerAnswer> MultipleChoiceQuestionTestTakerAnswers { get; set; } 



    }
}
