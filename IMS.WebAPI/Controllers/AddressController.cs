using IMS.Application.Features.Address.Command;
using IMS.Application.Features.Address.Queries;
using IMS.Core.Common.Helper;
using IMS.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddAddress")]
        public async Task<GenericBaseResult<string>> AddAddress([FromBody] AddAddressCommand command)
        {
            try
            {
                var addressId = await _mediator.Send(command);
                return new GenericBaseResult<string>(addressId);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<string>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }

        [HttpPost]
        [Route("UpdateAddress")]
        public async Task<GenericBaseResult<bool>> UpdateAddress([FromBody] UpdateAddressCommand command)
        {
            try
            {
                var res = await _mediator.Send(command);
                return new GenericBaseResult<bool>(res);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<bool>(false);
                result.AddExceptionLog(ex);
                return result;
            }
        }

        [HttpPost]
        [Route("DeleteAddress")]
        public async Task<GenericBaseResult<bool>> DeleteAddress([FromBody] DeleteAddressCommand command)
        {
            try
            {
                var res = await _mediator.Send(command);
                return new GenericBaseResult<bool>(res);
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<bool>(false);
                result.AddExceptionLog(ex);
                return result;
            }
        }


        [HttpGet("GetAddressesByUserId/{userId}")]
        public async Task<GenericBaseResult<List<AddressTbl>>> GetAddressesByUserId(string userId)
        {
            try
            {
                var query = new GetAddressesByUserIdQuery(userId);
                var addresses = await _mediator.Send(query);
                return new GenericBaseResult<List<AddressTbl>>(addresses);

            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<List<AddressTbl>>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }


        [HttpGet("GetPrimaryAddressByUserId/{userId}")]
        public async Task<GenericBaseResult<AddressTbl>> GetPrimaryAddressByUserId(string userId)
        {
            try
            {
                var query = new GetPrimaryAddressByUserIdQuery(userId);
                var address = await _mediator.Send(query);
                return new GenericBaseResult<AddressTbl>(address);

            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<AddressTbl>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }
    }

}
