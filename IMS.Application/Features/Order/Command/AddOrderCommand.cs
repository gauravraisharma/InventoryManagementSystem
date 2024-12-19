using IMS.Core.Common.Entities;
using MediatR;

namespace IMS.Application.Features.Order.Command
{
    public class AddOrderCommand : IRequest
    {
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderProductDetails> ProductDetails { get; set; }

        public AddOrderCommand(string customerId, DateTime orderDate, decimal totalAmount, List<OrderProductDetails> productDetails)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            ProductDetails = productDetails;
        }
    }

}
