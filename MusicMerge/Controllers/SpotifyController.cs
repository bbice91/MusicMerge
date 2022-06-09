using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMerge.Data;
using MetaBrainz.MusicBrainz;
using MetaBrainz.MusicBrainz.Interfaces.Searches;
using System.Text.Json;

namespace MusicMerge
{
    public class SpotifyResponse
    {
        public string ClientId { get; set; }
        public string ResponseType { get; set; }
        public string RedirectUri { get; set; }
        public string State { get; set; }
        public string Scope { get; set; }
        public string ShowDialog { get; set; }
    }

    public class SpotifyRequestModel
    {
        public string Client_Id { get; set; }
        public string Scopes { get; set; }
        public string Redirect_Uri { get; set; }

    }


    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly MusicMergeContext _context;

        public SpotifyController(MusicMergeContext context)
        {
            _context = context;
        }


        /*[HttpGet("/callback/")]
        public SpotifyResponse GetSpotifyAuthorizationResponse(string client_id, string client_secret, string redirect_uri)
        {
            var url = $"https://coverartarchive.org/release/{mbid}";
            var client = new HttpClient();

            var httpResponse = client.GetAsync(url).Result;
            var albumArtReceipt = httpResponse.Content.ReadAsStringAsync().Result;

            var response = JsonSerializer.Deserialize<AlbumArtResponse>(albumArtReceipt);
            var image1 = response.images.First();

            var artistAlbumArt = new AlbumArt()
            {
                Image = image1.image,
                LargeImage = image1.thumbnails.large
            };
            return artistAlbumArt;  
        }


        [HttpGet("/loginRequest/")]
        public SpotifyResponse SpotifyLoginRequest()
        {
            // Make sure "http://localhost:5265" is in your applications redirect URIs!
            var loginRequest = new LoginRequest(
              new Uri("http://localhost:5265"),
              "ClientId",
              LoginRequest.ResponseType.Code
            )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
            };
            var uri = loginRequest.ToUri();
            // Redirect user to uri via your favorite web-server

            return uri;
        }


        private bool AlbumArtExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
