using MediatR;

namespace IMS.Application.Features.Auth.Command
{
    public class LoginCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
