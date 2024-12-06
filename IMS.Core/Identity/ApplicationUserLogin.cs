
using Microsoft.AspNetCore.Identity;

namespace IMS.Core.Identity
{
public class ApplicationUserLogin : IdentityUserLogin<string>
{
    public virtual ApplicationUser User { get; set; } = default!;
}
}