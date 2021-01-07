using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MyNewLanguage.Models.Identity
{
    public class User : IdentityUser<int>
    {
        [Required(ErrorMessage = "{0} required")]
        [StringLength(35, MinimumLength = 3)]
        public string FullName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public string JsonWebToken { get; set; }
    }
}