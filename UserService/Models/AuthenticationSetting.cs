namespace UserService.Models
{
    public class AuthenticationSetting
    {
        public string SecretKey { get; set; }
        public int ExpiresInSecond { get; set; }
        public string Audience { get; set; }
    }
}
