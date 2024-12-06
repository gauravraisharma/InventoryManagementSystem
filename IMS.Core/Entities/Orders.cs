using IMS.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class Orders:BaseAuditableEntity
    {
        public string CustomerId { get; set; }
        public string ProductId { get; set; } 
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ShipmentDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }
}
