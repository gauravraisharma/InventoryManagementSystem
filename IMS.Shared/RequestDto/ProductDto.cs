using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.RequestDto
{
    public class GetAllDepartmentDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; }
    }
}
