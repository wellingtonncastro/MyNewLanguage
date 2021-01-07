using System.ComponentModel.DataAnnotations;

namespace MyNewLanguage.Dtos
{
    public class UserLoginDto
    {   
        [Required(ErrorMessage = "{0} required")]     
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        public string PasswordHash { get; set; }    
    }
}