using System.Net.Http.Headers;
using System.Text.Json;

namespace MusicMerge
{
    public class CoverArtService
    {
        private readonly HttpClient _httpClient;

        public CoverArtService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<AlbumArt> GetAlbumArtByArtId(string mbid, string name)
        {
            var url = $"https://coverartarchive.org/release/{mbid}";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpResponse = client.GetAsync(url).Result;
            var albumArtReceipt = httpResponse.Content.ReadAsStringAsync().Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<AlbumArtResponse>(albumArtReceipt);
                var image1 = response.images.First();

                var artistAlbumArt = new AlbumArt()
                {
                    Image = image1.image,
                    LargeImage = image1.thumbnails.large,
                    Id = mbid,
                    Name = name
                };
                return artistAlbumArt;
            }

            return null;
        }
    }
}
