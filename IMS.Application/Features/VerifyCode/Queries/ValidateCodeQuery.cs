using MediatR;

namespace IMS.Application.Features.VerifyCode.Queries
{
    public class ValidateCodeQuery : IRequest<bool>
    {
        public string Email { get; set; }
        public string Code { get; set; }

        public ValidateCodeQuery(string email, string code)
        {
            Email = email;
            Code = code;
        }
    }
}
