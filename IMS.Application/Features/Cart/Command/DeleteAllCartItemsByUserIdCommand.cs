using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Cart.Command
{
    public class DeleteAllCartItemsByUserIdCommand : IRequest<bool>
    {
        public string UserId { get; set; }
    }

}
