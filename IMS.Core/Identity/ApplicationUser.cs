using IMS.Core.Common.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IMS.Core.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IMS.Core.Identity
{



public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        UserClaims = new HashSet<ApplicationUserClaim>();
        UserRoles = new HashSet<ApplicationUserRole>();
        Logins = new HashSet<ApplicationUserLogin>();
        Tokens = new HashSet<ApplicationUserToken>();
    }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
   
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public virtual ICollection<ApplicationUserClaim> UserClaims { get; set; }
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
    public virtual ICollection<ApplicationUserToken> Tokens { get; set; }


}
}

//public DateTime? Created { get; set; }
//public string? CreatedBy { get; set; }
//public ApplicationUser? CreatedByUser { get; set; } = null;
//public DateTime? LastModified { get; set; }
//public string? LastModifiedBy { get; set; }
//public ApplicationUser? LastModifiedByUser { get; set; } = null;