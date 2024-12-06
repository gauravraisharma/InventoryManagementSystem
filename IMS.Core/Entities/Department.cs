using IMS.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class Department : BaseAuditableEntity
    {
        public string Name { get; set; }
        public ICollection<DepartmentProductMapping> DepartmentProductMapping { get; set; } = new List<DepartmentProductMapping>();
    }
}
