using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.RequestDto.ProductDTOs
{
    public class AddProductDto
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Please provide a title for the product.")]
        [StringLength(200, ErrorMessage = "The title cannot be longer than 200 characters.")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please provide a description for the product.")]
        [StringLength(200, ErrorMessage = "The description cannot be longer than 200 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please provide a unit price for the product.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The unit price must be a positive number greater than zero.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Please specify the units in stock.")]
        [Range(0, int.MaxValue, ErrorMessage = "The units in stock must be a non-negative number.")]
        public int UnitsInStock { get; set; }

        [Required(ErrorMessage = "Please provide a product code.")]
        [StringLength(50, ErrorMessage = "The product code cannot be longer than 50 characters.")]
        public string ProductCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select at least one category for the product.")]
        public List<string> CategoryIds { get; set; } = new List<string>();

        public List<string> DepartmentIds { get; set; } = new List<string>();

        [Required(ErrorMessage = "Please upload at least one image file for the product.")]
        public List<IBrowserFile> ImageFiles { get; set; } = new List<IBrowserFile>();

        [Required(ErrorMessage = "Please provide at least one image URL.")]
        public List<string> ProductImages { get; set; } = new List<string>();

        [Required(ErrorMessage = "Please specify at least one size for the product.")]
        public List<string> ProductSizes { get; set; } = new List<string>();
    }

    public class UploadedFile
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }




}
