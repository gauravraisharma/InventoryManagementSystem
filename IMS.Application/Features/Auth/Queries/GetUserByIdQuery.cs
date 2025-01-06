using IMS.Core.Identity;
using IMS.Core.RequestDto;
using MediatR;

namespace IMS.Application.Features.Auth.Queries
{
    public class GetUserByIdQuery : IRequest<ApplicationUser>
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQuery"/> class.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
