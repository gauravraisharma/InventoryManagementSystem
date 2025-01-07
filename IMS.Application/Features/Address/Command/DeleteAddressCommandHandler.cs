using IMS.Infrastructure.Interface.Address;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace IMS.Application.Features.Address.Command
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand,bool>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = await _addressRepository.GetByIdAsync(request.Id);
                if (address == null)
                {
                    throw new NotFoundException("Address not found");
                }
                address.IsDelete = true;
                address.IsActive = false;
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
