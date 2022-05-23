using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMerge.Data;
using MetaBrainz.MusicBrainz;

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

        //[HttpGet("{artist}")]
        //public async Task<ActionResult<Album>> GetAlbumsByArtist(string artist)
        //{
        //    var q = new Query();
        //    q.FindArtists("artist", simple: true);
        //    return (q);
        //}

        private bool AlbumExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
