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

    [Route("api/[controller]")]
    [ApiController]
    public class CoverArtArchiveController : ControllerBase
    {
        private readonly MusicMergeContext _context;
        private readonly CoverArtService _coverArtService;

        public CoverArtArchiveController(MusicMergeContext context, CoverArtService coverArtService)
        {
            _context = context;
            _coverArtService = coverArtService;
        }



        private bool AlbumArtExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
