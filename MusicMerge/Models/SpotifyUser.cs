using System;

namespace MusicMerge.Models
{
    public class SpotifyUser
    {
        public string id { get; set; }
        public string displayName { get; set; }

        public DateTime createdDate { get; set; }

        public string email { get; set; }
        public object externalUrls { get; set; }

        public string product { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public object followers { get; set; }
        public string login { get; set; }



       

    }
}
