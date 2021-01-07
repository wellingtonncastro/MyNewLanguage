using System.ComponentModel.DataAnnotations;

namespace MyNewLanguage.Dtos
{
    public class UserDto
    {
        public int Id {get;set;}
        
        [Required(ErrorMessage = "{0} required")]
        [StringLength(35, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        public string PasswordHash { get; set; }    
    }
}