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

namespace MusicMerge
{
    public class Release
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }


    public class AlbumArt
    {
        public string? Image { get; set; }
        public string? LargeImage { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class MusicBrainzController : ControllerBase
    {
        private readonly MusicMergeContext _context;
        private readonly CoverArtService _coverArtService;

        public MusicBrainzController(MusicMergeContext context, CoverArtService coverArtService)
        {
            _context = context;
            _coverArtService = coverArtService;
        }


        [HttpGet("{artist}")]
        public async Task<IActionResult> GetAlbumsByArtist(string artist) // IEnumerable<Album>
        {
            if (artist is null)
            {
                return NotFound();
            }

            var q = new Query();
            var artistList = q.FindArtists(artist);

            if (artistList.TotalResults == 0)
            {
                return NotFound();
            }

            var artistEntry = artistList.Results.First().Item;

            //var name = artistEntry.Name;
            var id = artistEntry.Id;

            var artist1 = q.LookupArtist(id, Include.Releases);

            var releases = artist1.Releases.Select(release => new Release() { Id = release.Id, Name = release.Title });

            if (releases == null)
            {
                return NotFound();
            }

            var reqests = releases.Select(release => _coverArtService.GetAlbumArtByArtId(release.Id.ToString(), release.Name));
            var albums = await Task.WhenAll(reqests);

            if (albums == null || !albums.Any())
            {
                return NotFound();
            }

            return Ok(albums.Where(x => x != null));
        }

        private bool AlbumExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
