using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoensioEvulatorApi.Data.Models
{
    public class FreeTextQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string TrueAnswerText { get; set; }
        public ICollection<Test> Tests { get; set; } 
        public ICollection<FreeTextQuestionTestTakerAnswer> FreeTextQuestionTestTakerAnswers { get; set; } 


    }
}
