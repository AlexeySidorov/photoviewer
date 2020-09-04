using System;
using Newtonsoft.Json;

namespace photoviewer.Domain.models
{
    public class Photo
    {
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime Create { get; set; }

        [JsonProperty("updated_at")]
        public DateTime Update { get; set; }

        public int Likes { get; set; }

        [JsonProperty("liked_by_user")]
        public bool LikedByUser { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("alt_description")]
        public string AltDescription { get; set; }

        public User User { get; set; }

        public Url Urls { get; set; }
    }
}
