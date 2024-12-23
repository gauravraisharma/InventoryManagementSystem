﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.RequestDto.orderDTOs
{
    public class AddOrderDto
    {
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderProductDetails> ProductDetails { get; set; }
    }
    public class OrderProductDetails
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
