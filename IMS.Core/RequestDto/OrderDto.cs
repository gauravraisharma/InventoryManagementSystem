using IMS.Core.Common.Entities;
using IMS.Core.Entities;

namespace IMS.Core.RequestDto
{
    public class OrderDto
    {
        public string OrderId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public AddressTbl? Address { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public List<OrderProductDetails> ProductDetails { get; set; }
    }

}
