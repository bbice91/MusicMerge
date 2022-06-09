using MusicMerge.Models;
using System.Text.Json;
using MusicMerge;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Text;
using System.Net;
using System.Collections.Specialized;

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
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", _config.RedirectUri }
            });

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://accounts.spotify.com/api/token"),
                Method = HttpMethod.Post,
                Content = httpParams,
            };

            var encodedToken = $"{_config.ClientId}:{_config.ClientSecret}";

            var encodedClientSecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(encodedToken));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", encodedClientSecret);

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

        public async Task<SpotifyUser> GetSpotifyUser(string token)
        {

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.spotify.com/v1/me"),
                Method = HttpMethod.Get,
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Headers.Add("Accept", "application/json");
            

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

            var user = JsonSerializer.Deserialize<SpotifyUser>(content, options);

            return user;
        }

        //public void GetClientCredentialsAuthToken()
        //{
        //    var spotifyClient = "be3700051b734c8c8cff0857f4e0f60d";
        //    var spotifySecret = "7cd175eca3b4ef88b93601f7e08c75e";

        //    var webClient = new WebClient();

        //    var postparams = new NameValueCollection();
        //    postparams.Add("grant_type", "client_credentials");

        //    var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{spotifyClient}:{spotifySecret}"));
        //    webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

        //    var tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);

        //    var textResponse = Encoding.UTF8.GetString(tokenResponse);
        //}
    }
}
