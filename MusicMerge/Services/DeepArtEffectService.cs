using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace MusicMerge.Services
{
    public class DeepArtEffectService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<DeepArtEffectSettings> _settings;

        public DeepArtEffectService(HttpClient httpClient, IOptions<DeepArtEffectSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<DeepArtStylesResponse> GetStyles()
        {
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _settings.Value.ApiKey);
            var stylesResponse = await _httpClient.GetAsync("https://api.deeparteffects.com/v1/noauth/styles");
            var responseContent = await stylesResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<DeepArtStylesResponse>(responseContent);
            return response;
        }

        public async Task<object> GetGeneratedImageProgess(string photoUrl, string id)
        {
            var imageResponse = await _httpClient.GetAsync(photoUrl);
            var imageBinary = await imageResponse.Content.ReadAsByteArrayAsync();
            var imageBase64 = Convert.ToBase64String(imageBinary);

            var request = new DeepArtRequest { styleId = id, imageBase64Encoded = imageBase64 };
            var requestJson = JsonSerializer.Serialize(request);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            requestContent.Headers.Add("x-api-key", _settings.Value.ApiKey);

            var httpResponse = await _httpClient.PostAsync("https://api.deeparteffects.com/v1/noauth/upload", requestContent);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<DeepArtResponse>(responseContent);

            var albumArtRequest = new GeneratedArtInProcess()
            {
                SubmissionId = response.submissionId
            };

            return albumArtRequest;
        }

        public async Task<GeneratedArtProgress> GetGeneratedImage(string submissionId)
        {
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _settings.Value.ApiKey);
            var httpResponse = await _httpClient.GetAsync($"https://api.deeparteffects.com/v1/noauth/result?submissionId={submissionId}");
            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<DeepArtImageResultResponse>(responseContent);

            var albumArtInProcess = new GeneratedArtProgress()
            {
                status = response.status,
                url = response.url
            };

            return albumArtInProcess;
        }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DeepArtStylesResponse
    {
        public List<Style> styles { get; set; }
    }

    public class Style
    {
        public string id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string description { get; set; }
    }



    class DeepArtRequest
    {
        public string? styleId { get; set; }
        public string? imageBase64Encoded { get; set; }
    }

    class DeepArtResponse
    {
        public string? submissionId { get; set; }
    }

    class DeepArtImageResultResponse
    {
        public string? status { get; set; }
        public string? url { get; set; }
    }

}
