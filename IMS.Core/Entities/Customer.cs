using IMS.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class Customer:BaseAuditableEntity
    {
        public string Name { get; set; }    
    }
}
