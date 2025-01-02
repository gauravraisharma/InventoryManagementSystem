using IMS.Core.Entities;

namespace IMS.Infrastructure.Interface.VerifyCode
{
    public interface IVerificationCodeRepository
    {
        Task AddOrUpdateAsync(VerificationCode verificationCode);
        Task AddOrUpdateForProfileAsync(VerificationCode verificationCode);
        Task<VerificationCode> GetByEmailAsync(string email);
        Task DeleteAsync(string email);
    }
}
