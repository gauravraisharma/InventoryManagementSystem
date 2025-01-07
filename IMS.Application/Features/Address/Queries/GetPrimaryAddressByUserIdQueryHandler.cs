using IMS.Core.Entities;
using IMS.Infrastructure.Interface.Address;
using MediatR;

namespace IMS.Application.Features.Address.Queries
{
    public class GetPrimaryAddressByUserIdQueryHandler : IRequestHandler<GetPrimaryAddressByUserIdQuery, AddressTbl>
    {
        private readonly IAddressRepository _addressRepository;

        public GetPrimaryAddressByUserIdQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressTbl> Handle(GetPrimaryAddressByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _addressRepository.GetPrimaryAddressByUserIdAsync(request.UserId);
                var primaryAddress = result.FirstOrDefault();
                if (primaryAddress != null) {
                    return primaryAddress;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
