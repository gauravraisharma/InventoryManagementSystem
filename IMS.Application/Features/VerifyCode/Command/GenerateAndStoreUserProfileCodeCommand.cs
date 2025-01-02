using MediatR;

namespace IMS.Application.Features.VerifyCode.Command
{
    public class GenerateAndStoreUserProfileCodeCommand : IRequest<string>
    {
        public string Email { get; set; }

        public GenerateAndStoreUserProfileCodeCommand(string email)
        {
            Email = email;
        }
    }
}
