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
    [Route("api/[controller]")]
    [ApiController]
    public class MusicBrainzController : ControllerBase
    {
        private readonly MusicMergeContext _context;

        public MusicBrainzController(MusicMergeContext context)
        {
            _context = context;
        }


       /* [HttpGet("{artist}")]
        public ISearchResults<Artist> GetAlbumsByArtist(string artist)
        {
            var q = new Query();

            q.FindArtists(artist);
            q.FindAllReleases(artist);
            return q;
        }*/


        private bool AlbumExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
