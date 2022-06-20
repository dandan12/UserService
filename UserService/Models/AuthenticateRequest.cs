using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class AuthenticateRequest
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
