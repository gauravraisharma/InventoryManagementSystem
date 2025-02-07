﻿using IMS.Shared.Common;
using IMS.Shared.RequestDto.orderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.Interface.Order
{
    public interface IOrderService
    {
        Task<ApiResponse<List<GetOrderDto>>> GetAllOrdersAsync();
        Task<ApiResponse<bool>> SaveOrderAsync(AddOrderDto orderRequest);
        Task<ApiResponse<List<GetOrderDto>>> GetAllUserOrdersAsync(string userId);
        Task<ApiResponse<GetOrderDto>> GetOrderByIdAsync(string orderId);
        Task<ApiResponse<string>> CreateStripeCheckoutSessionAsync(AddOrderDto orderRequest);
    }
}
