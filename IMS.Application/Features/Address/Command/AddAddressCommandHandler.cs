using IMS.Core.Entities;
using IMS.Infrastructure.Interface.Address;
using MediatR;

namespace IMS.Application.Features.Address.Command
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, string>
    {
        private readonly IAddressRepository _addressRepository;

        public AddAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<string> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = new AddressTbl
                {
                    City = request.City,
                    Street = request.Street,
                    Country = request.Country,
                    IsActive = request.IsActive,
                    UserId = request.UserId
                };

                return await _addressRepository.AddAsync(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
