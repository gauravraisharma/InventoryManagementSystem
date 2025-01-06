using IMS.Core.Common.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Order.Command
{
    public class CreateStripeCheckoutSessionCommand : IRequest<string>
    {
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderProductDetails> ProductDetails { get; set; }

        public CreateStripeCheckoutSessionCommand(string customerId, DateTime orderDate, decimal totalAmount, List<OrderProductDetails> productDetails)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            ProductDetails = productDetails;
        }
    }
}
