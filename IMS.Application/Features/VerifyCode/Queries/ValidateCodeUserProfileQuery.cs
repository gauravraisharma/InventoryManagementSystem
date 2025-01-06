using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IMS.Application.Features.VerifyCode.Queries
{
    public class ValidateCodeUserProfileQuery : IRequest<bool>
    {
        public string Email { get; set; }
        public string Code { get; set; }

        public ValidateCodeUserProfileQuery(string email, string code)
        {
            Email = email;
            Code = code;
        }
    }
}
