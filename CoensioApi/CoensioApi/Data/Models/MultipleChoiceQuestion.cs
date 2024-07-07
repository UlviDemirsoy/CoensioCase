using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoensioApi.Data.Models
{
    public class MultipleChoiceQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string Options { get; set; }
        [Required]
        public string TrueAnswer { get; set; }
        public ICollection<Test> Tests { get; set; } 
        public ICollection<MultipleChoiceQuestionTestTakerAnswer> MultipleChoiceQuestionTestTakerAnswers { get; set; } 



    }
}
