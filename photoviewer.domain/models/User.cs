using Newtonsoft.Json;

namespace photoviewer.domain.models
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("profile_image")]
        public ProfileImageModel ProfileImages { get; set; }
    }
}
