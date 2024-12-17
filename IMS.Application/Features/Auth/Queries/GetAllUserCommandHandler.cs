using IMS.Core.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IMS.Application.Features.Auth.Queries
{
    public class GetAllUserCommandHandler : IRequestHandler<GetAllUserCommand, List<ApplicationUser>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetAllUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ApplicationUser>> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userManager.GetUsersInRoleAsync("user");
                return users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve users", ex);
            }
        }
    }
}
