using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IMS.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {
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

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
    }
}