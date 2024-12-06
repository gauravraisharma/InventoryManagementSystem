using IMS.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class ProductImages: BaseAuditableEntity
    {
        [Column(TypeName = "nvarchar(max)")] 
        public string Base64Image { get; set; }
        public string Name { get; set; }
        public string ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
