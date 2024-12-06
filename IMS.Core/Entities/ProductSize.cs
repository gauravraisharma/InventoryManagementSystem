using IMS.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class ProductSize:BaseAuditableEntity
    {
       
        public string Size { get; set; }
        public string ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        
    }
}
