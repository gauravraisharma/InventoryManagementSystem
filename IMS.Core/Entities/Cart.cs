using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMS.Core.Common.Entities;

namespace IMS.Core.Entities
{
    public class Cart : BaseAuditableEntity
    {
        [ForeignKey("AspNetUsers")]
        [Required]
        public string UserId { get; set; }

        [Required]
        public string ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public string ProductSizeId { get; set; }

        [ForeignKey(nameof(ProductSizeId))]
        public virtual ProductSize ProductSize { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
