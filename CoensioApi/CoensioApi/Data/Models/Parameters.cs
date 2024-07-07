using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoensioApi.Data.Models
{
    public class Parameters
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }

    }
}
