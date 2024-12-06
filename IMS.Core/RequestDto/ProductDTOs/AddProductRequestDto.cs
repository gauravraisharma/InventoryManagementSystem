//using IMS.Core.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.RequestDto.ProductDTOs
{
    public class AddProductRequestDto
    {
        public string ?Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Unit Price must be a positive number.")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Units in Stock must be a non-negative number.")]
        public int UnitsInStock { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductCode { get; set; }

        //[Required]
        //public Department Department { get; set; }
        [Required]
        public List<string> CategoryIds { get; set; } = new List<string>();
        public List<string> DepartmentIds { get; set; } = new List<string>();

        //public List<string> ImageUrls { get; set; } = new List<string>();
        public List<IFormFile> ImageFiles { get; set; } = new List<IFormFile>();
        public List<string> ProductSizes { get; set; } = new List<string>();
    }
}
