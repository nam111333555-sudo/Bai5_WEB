using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookDB.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }
    }
}
