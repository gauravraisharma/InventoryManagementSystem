using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.RequestDto.ProductDTOs
{
    public class ProductFilterDto
    {
        public string Department { get; set; } = "all";
        public string Category { get; set; } = "all";   
        public string SearchText { get; set; } = string.Empty; 
        public string SortBy { get; set; } = "newest";  
    }

}
