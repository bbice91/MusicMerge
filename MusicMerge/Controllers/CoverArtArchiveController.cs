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
using System.Net.Http.Headers;

namespace MusicMerge
{
    public class AlbumArt
    {
        public string? Image { get; set; }
        public string? LargeImage { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CoverArtArchiveController : ControllerBase
    {
        private readonly MusicMergeContext _context;

        public CoverArtArchiveController(MusicMergeContext context)
        {
            _context = context;
        }


        [HttpGet("/release/{mbid}")]
        public AlbumArt GetAlbumArtByReleaseMbid(Guid mbid)
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
                LargeImage = image1.thumbnails.large
            };
            return artistAlbumArt;  

            }

            return null;
        }


        private bool AlbumArtExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
