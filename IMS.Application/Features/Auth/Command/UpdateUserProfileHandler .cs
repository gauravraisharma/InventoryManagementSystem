using IMS.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Features.Auth.Command
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUserProfileHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return false; 

            user.Email = request.Email;
            user.PhoneNumber = request.Phone;
            user.UserName = request.Email; 

            if (user is ApplicationUser appUser) 
            {
                appUser.FirstName = request.FirstName;
                appUser.LastName = request.LastName;
            }

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded; 
        }
    }
}
