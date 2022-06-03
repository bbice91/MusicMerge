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

namespace MusicMerge
{

    public class GenerateArtRequest
    {
        public string Photo_Url { get; set; }
        public string Style_Id { get; set; }

    }
    public class GeneratedArtInProcess
    {
        public string? Result { get; set; }
        public int? Photo_Id { get; set; }
        public int? Filterjob_id { get; set; }
    }

    public class GeneratedArtProgress
    {
        public string? Result { get; set; }
        public string? Status { get; set; }
        public int? Progress { get; set; }
        public string? Url { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class NeuralStyleController : ControllerBase
    {
        private readonly MusicMergeContext _context;

        public NeuralStyleController(MusicMergeContext context)
        {
            _context = context;
        }


        [HttpGet("/generateArt/{photo_url}/{styleId}/")]
        public  GeneratedArtInProcess GenerateAlbumArt(string photo_url, string styleId)
        {
            var requestParams = new GenerateArtRequest { Photo_Url = photo_url, Style_Id = styleId }; 
            var url = $"https://neuralstyle.art/api.json/photo_url={photo_url}&api_key=NSHEBJXXFIOYFOIFXFSMIPJOVGXYZJLHYNKOASKTFLOUANXZ&style_id={styleId}";
            var client = new HttpClient();

            var httpResponse = client.GetAsync(url).Result;
            var albumArtMergeRequest = httpResponse.Content.ReadAsStringAsync().Result;

            var response = JsonSerializer.Deserialize<NeuralStyleResponse>(albumArtMergeRequest);

            var albumArtInProcess = new GeneratedArtInProcess()
            {
                Result = response.Result,
                Photo_Id = response.Pid,
                Filterjob_id = response.Filterjob_id

            };

            return albumArtInProcess;  
        }


        [HttpGet("/render/{photo_url}")]
        public GeneratedArtProgress QueryAlbumArtProgress(string filterjob_id)
        {
            var url = $"https://neuralstyle.art/api/{filterjob_id}.json?api_key=NSHEBJXXFIOYFOIFXFSMIPJOVGXYZJLHYNKOASKTFLOUANXZ";
            var client = new HttpClient();

            var httpResponse = client.GetAsync(url).Result;
            var albumArtMergeRequest = httpResponse.Content.ReadAsStringAsync().Result;

            var response = JsonSerializer.Deserialize<NeuralStyleProgressResponse>(albumArtMergeRequest);
            var imageInProcess = response;

            var albumArtInProcess = new GeneratedArtProgress()
            {
                Result = response.result,
                Status = response.status,
                Progress = response.progress,
                Url = response.url
            };

            return albumArtInProcess;
        }

        private bool AlbumArtExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
