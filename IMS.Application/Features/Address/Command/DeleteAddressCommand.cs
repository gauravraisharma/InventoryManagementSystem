using MediatR;

namespace IMS.Application.Features.Address.Command
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
