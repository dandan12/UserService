using Newtonsoft.Json;
using UserService.Attributes;
using UserService.Utils.Constants;

namespace UserService.Entities
{
    [CosmosContainer(ContainerConstant.Partners)]
    public class Partner : BaseEntity
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("contact_number")]
        public string ContactNumber { get; set; }

        [JsonProperty("url_callback")]
        public string UrlCallback { get; set; }
    }
}
