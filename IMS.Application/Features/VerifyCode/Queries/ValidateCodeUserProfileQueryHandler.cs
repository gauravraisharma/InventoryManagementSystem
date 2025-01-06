using IMS.Infrastructure.Interface.VerifyCode;
using MediatR;

namespace IMS.Application.Features.VerifyCode.Queries
{
    public class ValidateCodeUserProfileQueryHandler : IRequestHandler<ValidateCodeUserProfileQuery, bool>
    {
        private readonly IVerificationCodeRepository _repository;

        public ValidateCodeUserProfileQueryHandler(IVerificationCodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ValidateCodeUserProfileQuery request, CancellationToken cancellationToken)
        {
            var email = "User_Profile" + request.Email;
            var verificationCode = await _repository.GetByEmailAsync(email);

            if (verificationCode != null && verificationCode.Code == request.Code && verificationCode.Expiry > DateTime.UtcNow)
            {
                await _repository.DeleteAsync(email);
                return true;
            }

            return false;
        }
    }
}
