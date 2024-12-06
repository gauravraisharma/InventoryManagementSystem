using IMS.Core.Common.Entities;
//using IMS.Core.Common.Enums;
using IMS.Core.Common.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IMS.Core.Entities
{
    public class Product:BaseAuditableEntity
    {
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        [StringLength(50)]
        public string ProductCode { get; set; }

        //public  Department Department { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }

    }
}
