using MusicMerge.Models;
using System.Text.Json;
using MusicMerge;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace MusicMerge.Services
{
    public class SpotifyService
    {
        private readonly SpotifyOAuthSettings _config;
        private readonly HttpClient _httpClient;

        public SpotifyService(HttpClient httpClient, IOptions<SpotifyOAuthSettings> config)
        {
            _config = config.Value;
            _httpClient = httpClient;
        }

        public async Task<SpotifyToken> GetToken(string code)
        {
            var httpParams = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "code", code },
                {"client_id", _config.ClientId },
                {"response_type", _config.ResponseType },
                {"redirect_uri", _config.RedirectUri },
                {"state", _config.State},
                {"scope", _config.Scope },
                {"show_dialog", _config.ShowDialog }
            });

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://accounts.spotify.com/api/token"),
                Method = HttpMethod.Post,
                Content = httpParams
            };

            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            SpotifyToken token = JsonSerializer.Deserialize<SpotifyToken>(content, options);
            return token;
        }

        public async Task<User> GetSpotifyUser(string token)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://accounts.spotify.com/authorize"),
                Method = HttpMethod.Post,
            };

            request.Headers.Add("Authorization", $"token {token}");
           // request.Headers.Add()

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var user = JsonSerializer.Deserialize<User>(content, options);

            return user;
        }
    }
}
