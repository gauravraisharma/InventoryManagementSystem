using IMS.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class Category: BaseAuditableEntity
    {
       
        public string Name { get; set; }
        public ICollection<CategoryProductMapping> CategoryProductMappings { get; set; } = new List<CategoryProductMapping>();
    }
}
    