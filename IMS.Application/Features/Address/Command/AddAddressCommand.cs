using MediatR;

namespace IMS.Application.Features.Address.Command
{
    public class AddAddressCommand : IRequest<string>
    {
        public string City { get; set; }
        public string? Street { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public string? Title { get; set; }
        public string? PinCode { get; set; }
        public string UserId { get; set; }  
    }

}
