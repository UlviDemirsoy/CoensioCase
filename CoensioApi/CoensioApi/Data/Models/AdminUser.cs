using System.ComponentModel.DataAnnotations;

namespace CoensioApi.Data.Models
{
    public class AdminUser
    {
        [Key]
        public string Email { get; set; }
    }
}
