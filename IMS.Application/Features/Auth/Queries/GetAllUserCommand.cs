using IMS.Core.Identity;
using MediatR;

namespace IMS.Application.Features.Auth.Queries
{
    public class GetAllUserCommand : IRequest<List<ApplicationUser>>
    {
    }
}
