using MediatR;

namespace IMS.Application.Features.VerifyCode.Command
{
    public class GenerateAndStoreCodeCommand : IRequest<string>
    {
        public string Email { get; set; }

        public GenerateAndStoreCodeCommand(string email)
        {
            Email = email;
        }
    }
}
