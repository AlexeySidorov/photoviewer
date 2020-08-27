using System;
using Newtonsoft.Json;
using photoviewer.domain.models;

namespace photoviewer.domain.Responses
{
    public struct PhotoResponse
    {
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime Create { get; set; }

        [JsonProperty("updated_at")]
        public DateTime Update { get; set; }

        public int Likes { get; set; }

        [JsonProperty("liked_by_user")]
        public bool LikedByUser { get; set; }

        public string Description { get; set; }

        public User User { get; set; }
        /*{
   
    "current_user_collections": [ // The *current user's* collections that this photo belongs to.
      {
        "id": 206,
        "title": "Makers: Cat and Ben",
        "published_at": "2016-01-12T18:16:09-05:00",
        "last_collected_at": "2016-06-02T13:10:03-04:00",
        "updated_at": "2016-07-10T11:00:01-05:00",
        "cover_photo": null,
        "user": null
      },
      // ... more collections
    ],
    "urls": {
      "raw": "https://images.unsplash.com/face-springmorning.jpg",
      "full": "https://images.unsplash.com/face-springmorning.jpg?q=75&fm=jpg",
      "regular": "https://images.unsplash.com/face-springmorning.jpg?q=75&fm=jpg&w=1080&fit=max",
      "small": "https://images.unsplash.com/face-springmorning.jpg?q=75&fm=jpg&w=400&fit=max",
      "thumb": "https://images.unsplash.com/face-springmorning.jpg?q=75&fm=jpg&w=200&fit=max"
    },
    "links": {
      "self": "https://api.unsplash.com/photos/LBI7cgq3pbM",
      "html": "https://unsplash.com/photos/LBI7cgq3pbM",
      "download": "https://unsplash.com/photos/LBI7cgq3pbM/download",
      "download_location": "https://api.unsplash.com/photos/LBI7cgq3pbM/download"
    }
  },*/
    }
}
