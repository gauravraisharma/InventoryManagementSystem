using MediatR;
using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace IMS.Application.Features.Order.Command
{
    public class CreateStripeCheckoutSessionCommandHandler : IRequestHandler<CreateStripeCheckoutSessionCommand, string>
    {
        private readonly IConfiguration _configuration;
        public CreateStripeCheckoutSessionCommandHandler( IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public async Task<string> Handle(CreateStripeCheckoutSessionCommand request, CancellationToken cancellationToken)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = request.ProductDetails.Select(product => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "inr",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = product.Name,
                        },
                        UnitAmount = (long)(product.Amount * 100),
                    },
                    Quantity = product.Quantity,
                }).ToList(),
                Mode = "payment",
                SuccessUrl = $"https://localhost:7093/success?sessionId={{CHECKOUT_SESSION_ID}}",
                CancelUrl = "https://localhost:7093/cancel",   
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return session.Url;
        }
    }
}
