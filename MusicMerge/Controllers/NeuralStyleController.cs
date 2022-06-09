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
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http.Headers;
using System.Text;
using MusicMerge.Services;

namespace MusicMerge
{
    public class GenerateArt
    {
        public string? photo { get; set; }
        public string? api_Key { get; set; }
        public string? style { get; set; }
    }

    public class GeneratedArtInProcess
    {
        public string? SubmissionId { get; set; }
    }

    public class GeneratedArtProgress
    {
        public string? status { get; set; }
        public string? url { get; set; }

    }


    [Route("api/[controller]")]
    [ApiController]
    public class NeuralStyleController : ControllerBase
    {
        private readonly MusicMergeContext _context;
        private readonly DeepArtEffectService _deepArtEffectService;

        public NeuralStyleController(MusicMergeContext context, DeepArtEffectService deepArtEffectService)
        {
            _context = context;
            _deepArtEffectService = deepArtEffectService;
        }

        [HttpGet("generateArt")]
        public async Task<IActionResult> GenerateAlbumArtAsync([FromQuery] string photo_url, [FromQuery] string style_id)
        {
            var newImage = await _deepArtEffectService.GetGeneratedImageProgess(photo_url, style_id);
            return Ok(newImage);
        }


        [HttpGet("getGeneratedArt/{submission_id}/{userId}")]
        public async Task<IActionResult> GetGeneratedArt(string submission_id, int userId)
        {
            var image = await _deepArtEffectService.GetGeneratedImage(submission_id);

            var generatedImage = new GeneratedImage
            {
                GeneratedImagePath = image.url,
                UserId = userId
            };

            _context.generatedImages.Add(generatedImage);
            await _context.SaveChangesAsync();

            return Ok(image);
        }

        [HttpGet]
        [Route("getImagesById/{id}")]
        public async Task<IActionResult> GetAllImagesById([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var images = _context.generatedImages.Where(i => i.UserId == user.Id).Select(i => i.GeneratedImagePath).ToList();
            return Ok(images);
        }
    }
}
