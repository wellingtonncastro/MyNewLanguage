namespace MyNewLanguage.Models.Identity
{
    public class AppSettings
    {
         public string Secret { get; set; }
        public int ExpireInHour { get; set; }
        public string Issuer { get; set; }
        public string ValidateIn { get; set; }
    }
}