using MediatR;

namespace IMS.Application.Features.Auth.Command
{
    public class UpdateUserProfileCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
    }
}
