using IMS.Application.Features.VerifyCode.Command;
using IMS.Application.Features.VerifyCode.Queries;
using IMS.Core.Common.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwoFactorAuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TwoFactorAuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("generate")]
        public async Task<GenericBaseResult<string>> GenerateCode(string email)
        {
            try
            {
                var code = await _mediator.Send(new GenerateAndStoreCodeCommand(email));
                return new GenericBaseResult<string>(code);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<string>(null);
                result.AddExceptionLog(ex);
                throw ex;
            }
        }


        [HttpGet]
        [Route("generateCodeForProfile")]
        public async Task<GenericBaseResult<string>> generateCodeForProfile(string email)
        {
            try
            {
                var code = await _mediator.Send(new GenerateAndStoreUserProfileCodeCommand(email));
                return new GenericBaseResult<string>(code);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<string>(null);
                result.AddExceptionLog(ex);
                throw ex;
            }
        }

        [HttpPost("validate")]
        public async Task<GenericBaseResult<bool>> ValidateCode([FromBody] ValidateCodeQuery query)
        {
            try
            {
                var isValid = await _mediator.Send(query);
                if (isValid)
                {
                    return new GenericBaseResult<bool>(true);
                }

                throw new Exception("InvalidCode");
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<string>(null);
                result.AddExceptionLog(ex);
                throw ex;
            }
        }


        [HttpPost("validateForUserProfile")]
        public async Task<GenericBaseResult<bool>> validateForUserProfile([FromBody] ValidateCodeUserProfileQuery query)
        {
            try
            {
                var isValid = await _mediator.Send(query);
                if (isValid)
                {
                    return new GenericBaseResult<bool>(true);
                }

                throw new Exception("InvalidCode");
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<string>(null);
                result.AddExceptionLog(ex);
                throw ex;
            }
        }
    }
}
