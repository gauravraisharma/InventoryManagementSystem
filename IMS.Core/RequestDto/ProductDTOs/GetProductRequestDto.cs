//using IMS.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.RequestDto.Product
{
    public class GetProductRequestDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ProductCode { get; set; }

        public List<string> ProductImages { get; set; } = new List<string>();
        public List<string> ProductSizes { get; set; } = new List<string>();
        public List<string> CategoryNames { get; set; } = new List<string>();
        public List<string> DepartmentNames { get; set; } = new List<string>();
        public List<string> CategoryIds { get; set; } = new List<string>();
        public List<string> DepartmentIds { get; set; } = new List<string>();
    }
}
