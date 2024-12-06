using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Identity
{
    public class ApplicationUserRole:IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; } = default!;
        public virtual ApplicationRole Role { get; set; } = default!;
    }
}
