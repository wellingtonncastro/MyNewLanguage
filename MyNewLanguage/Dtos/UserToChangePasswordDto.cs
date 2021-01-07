namespace MyNewLanguage.Dtos
{
    public class UserToChangePasswordDto
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public string NewPasswordHash { get; set; }
    }
}