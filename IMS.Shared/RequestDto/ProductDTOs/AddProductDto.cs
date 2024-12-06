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

        //[Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string? Description { get; set; }

        //[Required(ErrorMessage = "Unit Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit Price must be a positive number.")]
        public decimal UnitPrice { get; set; }

      //  [Required(ErrorMessage = "Units in Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Units in Stock must be a non-negative number.")]
        public int UnitsInStock { get; set; }

       // [Required(ErrorMessage = "Product Code is required.")]
        [StringLength(50, ErrorMessage = "Product Code cannot exceed 50 characters.")]
        public string ProductCode { get; set; } = string.Empty;

       // [Required(ErrorMessage = "At least one Category ID is required.")]
        public List<string> CategoryIds { get; set; } = new List<string>();

        public List<string> DepartmentIds { get; set; } = new List<string>();

        public List<IBrowserFile> ImageFiles { get; set; } = new List<IBrowserFile>();
        //public List<FileDto> ImageFiles { get; set; }

        public List<string> ProductSizes { get; set; } = new List<string>();
    }
    //public class FileDto
    //{
    //    public string Base64Image { get; set; }
    //    public string FileName { get; set; }
    //}
    public class UploadedFile
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }




}
