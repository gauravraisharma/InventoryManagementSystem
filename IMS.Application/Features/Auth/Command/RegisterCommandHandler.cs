using IMS.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Features.Auth.Command
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager; 

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var roleExists = await _roleManager.RoleExistsAsync("User");
            if (!roleExists)
            {
                return false;
            }


            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return false;
            }

            var role = await _roleManager.FindByNameAsync("User");
            if (role == null)
            {
                return false; 
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
            if (!addToRoleResult.Succeeded)
            {
                return false;
            }
            return true;
        }
    }
}
