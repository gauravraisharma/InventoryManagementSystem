using IMS.Core.Entities;
using MediatR;

namespace IMS.Application.Features.Address.Queries
{
    public class GetPrimaryAddressByUserIdQuery : IRequest<AddressTbl>
    {
        public string UserId { get; set; }

        public GetPrimaryAddressByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
