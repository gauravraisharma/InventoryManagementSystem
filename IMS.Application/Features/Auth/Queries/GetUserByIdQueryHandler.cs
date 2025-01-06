using IMS.Core.Identity;
using IMS.Core.RequestDto;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Features.Auth.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserByIdQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new KeyNotFoundException($"User with ID {request.UserId} not found.");
                }

                //return new UserDto
                //{
                //    Id = user.Id,
                //    Name = user.FirstName + user.LastName, 
                //    Username = user.UserName,
                //    Email = user.Email,
                //    PhoneNumber = user.PhoneNumber
                //};
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve user", ex);
            }
        }
    }
}
