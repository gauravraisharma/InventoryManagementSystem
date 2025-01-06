using IMS.Infrastructure.Interface.Address;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace IMS.Application.Features.Address.Command
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = await _addressRepository.GetByIdAsync(request.Id);
                if (address == null)
                {
                    throw new NotFoundException("Address not found");
                }

                var userAddresses = await _addressRepository.GetAddressesByUserIdAsync(request.UserId);
                if (userAddresses == null || !userAddresses.Any())
                {
                    throw new NotFoundException("No addresses found for the user");
                }

                foreach (var userAddress in userAddresses)
                {
                    if (userAddress.Id != request.Id)
                    {
                        userAddress.IsActive = false;
                        await _addressRepository.UpdateAsync(userAddress);
                    }
                }

                address.City = request.City;
                address.Street = request.Street;
                address.Country = request.Country;
                address.IsActive = request.IsActive;

                await _addressRepository.UpdateAsync(address);
                return true;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
