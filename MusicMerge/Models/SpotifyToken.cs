using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicMerge.Models
{
    public class SpotifyToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        public string Scope { get; set; }

        [JsonPropertyName("resonse_type")]
        public string ResponseType { get; set; }
    }
}
