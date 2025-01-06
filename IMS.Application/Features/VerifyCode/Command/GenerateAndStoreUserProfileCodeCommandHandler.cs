using IMS.Core.Common.Helper;
using IMS.Core.Entities;
using IMS.Core.Identity;
using IMS.Infrastructure.Interface.VerifyCode;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Features.VerifyCode.Command
{
    public class GenerateAndStoreUserProfileCodeCommandHandler : IRequestHandler<GenerateAndStoreUserProfileCodeCommand, string>
    {

        private readonly IVerificationCodeRepository _repository;
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;

        public GenerateAndStoreUserProfileCodeCommandHandler(IVerificationCodeRepository repository, IEmailService emailService, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _emailService = emailService;
            _userManager = userManager;
        }

        public async Task<string> Handle(GenerateAndStoreUserProfileCodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var code = new Random().Next(100000, 999999).ToString();
                var expiry = DateTime.UtcNow.AddMinutes(15);

                var verificationCode = new VerificationCode
                {
                    Email = "User_Profile" + request.Email,
                    Code = code,
                    Expiry = expiry
                };

                await _repository.AddOrUpdateForProfileAsync(verificationCode);

                var subject = "Your User Profile Verification Code";
                var message = $"Your user profile verification code is {code}. It will expire in 15 minutes.";
                await _emailService.SendEmailToCustomer(request.Email, subject, message);

                return code;

            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }
    }
}
