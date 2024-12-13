using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.RequestDto.CartDTOs
{
    public class CartDto
    {
        public string CartId { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string ProductSizeId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductSize { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public List<string> ProductImageUrls { get; set; }
    }
}
