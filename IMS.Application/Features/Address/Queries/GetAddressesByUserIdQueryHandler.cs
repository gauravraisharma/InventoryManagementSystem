using IMS.Core.Entities;
using IMS.Infrastructure.Interface.Address;
using MediatR;

namespace IMS.Application.Features.Address.Queries
{
    public class GetAddressesByUserIdQueryHandler : IRequestHandler<GetAddressesByUserIdQuery, List<AddressTbl>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAddressesByUserIdQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<AddressTbl>> Handle(GetAddressesByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _addressRepository.GetAddressesByUserIdAsync(request.UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
