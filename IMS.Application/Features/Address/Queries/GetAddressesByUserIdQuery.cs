using IMS.Core.Entities;
using MediatR;

namespace IMS.Application.Features.Address.Queries
{
    public class GetAddressesByUserIdQuery : IRequest<List<AddressTbl>>
    {
        public string UserId { get; set; }

        public GetAddressesByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

}
