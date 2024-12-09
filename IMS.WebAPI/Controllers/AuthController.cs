using IMS.Application.Features.Auth.Command;
using IMS.Core.Common.Helper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<GenericBaseResult<bool>> Register([FromBody] RegisterCommand command)
        {
            try
            {
                var isSuccess = await _mediator.Send(command);
                if (isSuccess)
                {
                    return new GenericBaseResult<bool>(isSuccess)
                    {
                        Message = "Registration successful"
                    };
                }
                else {
                    throw new Exception("Registration Failed");
                }

            }
            catch (Exception ex)
            {

                var result = new GenericBaseResult<bool>(false);
                result.AddExceptionLog(ex);
                return result;
            }
        }

        [HttpPost("login")]
        public async Task<GenericBaseResult<string>> Login([FromBody] LoginCommand command)
        {
            try
            {
                var authResponse = await _mediator.Send(command);
                return new GenericBaseResult<string>(authResponse); 
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<string>("Login Failed");
                result.AddExceptionLog(ex);
                return result;
            }
        }
    }
}
