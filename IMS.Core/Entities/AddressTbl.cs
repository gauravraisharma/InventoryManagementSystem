using IMS.Core.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IMS.Core.Entities
{
    public class AddressTbl : BaseAuditableEntity
    {
        [ForeignKey("AspNetUsers")]
        [Required]
        public string UserId { get; set; }
        public string City { get; set; }
        public string? Street { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; } = false;

    }
}
