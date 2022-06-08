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

        public NeuralStyleController(MusicMergeContext context)
        {
            _context = context;
        }

        class DeepArtRequest
        {
            public string? styleId { get; set; }
            public string? imageBase64Encoded { get; set; }
        }

        class DeepArtResponse
        {
            public string? submissionId { get; set; }
        }

        class DeepArtImageResultResponse
        {
            public string? status { get; set; }
            public string? url { get; set; }
        }

        [HttpGet("generateArt")]
        public GeneratedArtInProcess GenerateAlbumArtAsync(string photo_url, string style_id)
        {
            var client = new HttpClient();
            var imageResponse = client.GetAsync(photo_url).Result;
            var imageBinary = imageResponse.Content.ReadAsByteArrayAsync().Result;
            var imageBase64 = Convert.ToBase64String(imageBinary);

            var request = new DeepArtRequest { styleId = style_id, imageBase64Encoded = imageBase64 };
            var requestJson = JsonSerializer.Serialize(request);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            requestContent.Headers.Add("x-api-key", "FcU8v502Pq5YdTrzylfaA1wUiNBaI9B847rXIr3W");

            var httpResponse = client.PostAsync("https://api.deeparteffects.com/v1/noauth/upload", requestContent).Result;
            var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            var response = JsonSerializer.Deserialize<DeepArtResponse>(responseContent);

            var albumArtRequest = new GeneratedArtInProcess
()
            {
                SubmissionId = response.submissionId
            };

            return albumArtRequest;

        }


        [HttpGet("getGeneratedArt/{submission_id}")]
        public GeneratedArtProgress GetGeneratedArt(string submission_id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", "FcU8v502Pq5YdTrzylfaA1wUiNBaI9B847rXIr3W");
            var httpResponse = client.GetAsync( "https://api.deeparteffects.com/v1/noauth/result?submissionId=" + submission_id).Result;
            var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            var response = JsonSerializer.Deserialize<DeepArtImageResultResponse>(responseContent);

            var albumArtInProcess = new GeneratedArtProgress()
            {
                status = response.status,
                url = response.url
            };

            return albumArtInProcess;
        }

        private bool AlbumArtExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
