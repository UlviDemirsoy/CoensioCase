using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoensioApi.Data.Models
{
    public class Test
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<CodingQuestion> CodingQuestions { get; set; }
        public ICollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public ICollection<FreeTextQuestion> FreeTextQuestions { get; set; }
        public virtual ICollection<AssesmentAssignment> AssesmentAssignments { get; set; }
    }
}
