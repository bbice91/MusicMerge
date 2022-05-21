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

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
          if (_context.Albums == null)
          {
              return NotFound();
          }
            return await _context.Albums.ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{artist}")]
        public async Task<ActionResult<Album>> GetAlbumsByArtist(string artist)
        {
            var q = new Query();
            q.FindRecordings(artist);
            return Ok(q);
        }
        private bool AlbumExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
