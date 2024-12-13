using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.Features.Cart.Command;
using IMS.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IMS.Application.Features.Cart.Handlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public AddToCartCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _context.Carts.FirstOrDefaultAsync
                (c => c.UserId == request.UserId
                                        && c.ProductId == request.ProductId
                                        && c.ProductSizeId == request.ProductSizeId, cancellationToken);

            if (cartItem == null)
            {
                cartItem = new Core.Entities.Cart
                {
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                    ProductSizeId = request.ProductSizeId,
                    Quantity = request.Quantity,
                    Created = DateTime.UtcNow,
                    CreatedBy = request.UserId
                };

                _context.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += request.Quantity;
                cartItem.LastModified = DateTime.UtcNow;
                cartItem.LastModifiedBy = request.UserId;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return cartItem.Id;
        }
    }
}
