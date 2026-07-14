using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EMSWebApp.Models
{
    public class AppUser : IdentityUser<int>
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
