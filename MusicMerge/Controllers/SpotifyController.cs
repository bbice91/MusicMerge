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

/*namespace MusicMerge
{
    public class SpotifyLoginSession
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
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


        [HttpGet]
        [Route("login/{code}/{authority}")]
        public async Task<IActionResult> Login([FromRoute] string code, [FromRoute] Authority authority)
        {
            var token = authority switch
            {
                Authority.Github => await _gitHubService.GetToken(code),
            };

            var githubUser = await _gitHubService.GetGithubUser(token.AccessToken);

            if (githubUser == null)
            {
                return Unauthorized();
            }

            // this is YOUR application DATABASE
            var user = await _userContext.UpsertGithubUser(githubUser, token.AccessToken);

            return Ok(user);
        }
        public class GithubToken
        {
            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; }

            public string Scope { get; set; }

            [JsonPropertyName("token_type")]
            public string TokenType { get; set; }
        }
    }

    private bool AlbumExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
*/
