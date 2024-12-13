using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.RequestDto.CartDTOs
{
    public class AddCartItemDto
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string ProductSizeName { get; set; }
        public int Quantity { get; set; }
    }
}
