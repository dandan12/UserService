using Newtonsoft.Json;

namespace UserService.Models
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("type")]
        public string TokenType { get; set; }
    }
}
