using Microsoft.AspNetCore.Identity;

namespace IMS.Core.Identity
{


public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public string? Description { get; set; }
    public string? Group { get; set; }
    public virtual ApplicationRole Role { get; set; } = default!;
}
}
