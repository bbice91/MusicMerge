﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicMerge.Models
{
    public class SpotifyToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        public string Scope { get; set; }


        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
