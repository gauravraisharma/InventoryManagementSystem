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

        [HttpPut]
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

        [HttpDelete]
        [Route("DeleteAddress/{id}")]
        public async Task<GenericBaseResult<bool>> DeleteAddress(string id)
        {
            try
            {
                var command = new DeleteAddressCommand { Id = id };
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
    }

}
