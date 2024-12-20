using System.ComponentModel.DataAnnotations;

namespace IMS.Core.Entities
{
    public class VerificationCode
    {
        [Key]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; } 

        [MaxLength(6)]
        [Required]
        public string Code { get; set; } 

        [Required]
        public DateTime Expiry { get; set; } 
    }
}
