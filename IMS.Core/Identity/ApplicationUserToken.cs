using Microsoft.AspNetCore.Identity;

namespace IMS.Core.Identity
{

public class ApplicationUserToken : IdentityUserToken<string>
{
    public virtual ApplicationUser User { get; set; } = default!;
}
}
