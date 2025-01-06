using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Core.Entities;
using IMS.Infrastructure.Interface.VerifyCode;
using IMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Services.VerifyCode
{
    public class VerificationCodeRepository : IVerificationCodeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VerificationCodeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrUpdateAsync(VerificationCode verificationCode)
        {
            try
            {
                var existingCode = await _dbContext.VerificationCodes
                    .FirstOrDefaultAsync(v => v.Email == verificationCode.Email);

                if (existingCode != null)
                {
                    _dbContext.VerificationCodes.Remove(existingCode);
                }

                _dbContext.VerificationCodes.Add(verificationCode);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddOrUpdateForProfileAsync(VerificationCode verificationCode)
        {
            try
            {
                var existingCode = await _dbContext.VerificationCodes
                    .FirstOrDefaultAsync(v => v.Email == verificationCode.Email);

                if (existingCode != null)
                {
                    _dbContext.VerificationCodes.Remove(existingCode);
                }

                _dbContext.VerificationCodes.Add(verificationCode);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<VerificationCode> GetByEmailAsync(string email)
        {
            try
            {
                return await _dbContext.VerificationCodes.FirstOrDefaultAsync(v => v.Email == email);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteAsync(string email)
        {
            try
            {
                var verificationCode = await _dbContext.VerificationCodes.FirstOrDefaultAsync(v => v.Email == email);

                if (verificationCode != null)
                {
                    _dbContext.VerificationCodes.Remove(verificationCode);
                    await _dbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
