using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.RequestDto.orderDTOs
{
    public class GetOrderDto
    {
        public string OrderId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? ShipmentDate { get; set; }

        public AddressDTO? Address { get; set; }
        public List<ProductDetailDto> ProductDetails { get; set; }
        public bool IsExpanded { get; set; } = false;
    }
    public class ProductDetailDto
    {
        public string ProductId { get; set; }
        public string Title { get; set; }
        public string ItemSize { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }

}
