using IMS.Infrastructure.Interface.VerifyCode;
using MediatR;

namespace IMS.Application.Features.VerifyCode.Queries
{
    public class ValidateCodeQueryHandler : IRequestHandler<ValidateCodeQuery, bool>
    {
        private readonly IVerificationCodeRepository _repository;

        public ValidateCodeQueryHandler(IVerificationCodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ValidateCodeQuery request, CancellationToken cancellationToken)
        {
            var verificationCode = await _repository.GetByEmailAsync(request.Email);

            if (verificationCode != null && verificationCode.Code == request.Code && verificationCode.Expiry > DateTime.UtcNow)
            {
                await _repository.DeleteAsync(request.Email);
                return true;
            }

            return false;
        }
    }
}
