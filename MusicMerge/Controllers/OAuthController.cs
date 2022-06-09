using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicMerge.Models;
using MusicMerge.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using MusicMerge;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using MusicMerge.Data;

namespace MusicMerge.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OAuthController : ControllerBase
    {
        private readonly SpotifyService _spotifyService;
        private readonly MusicMergeContext _userContext;

        public OAuthController(MusicMergeContext userContext, SpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            _userContext = userContext;
        }

        [HttpGet]
        [Route("login/{code}")]
        public async Task<IActionResult> Login([FromRoute] string code)
        {
            var token = await _spotifyService.GetToken(code);

            var spotifyUser = await _spotifyService.GetSpotifyUser(token.AccessToken);

            if (spotifyUser == null)
            {
                return Unauthorized();
            }

            var user = await _userContext.UpsertSpotifyUser(spotifyUser, token.AccessToken);

            return Ok(user);
        }

        [HttpPost]
        [Route("/api/token")]

        public async Task<IActionResult> GetAccess([FromRoute] string accessToken)
        {
            return Ok(accessToken);
        }

    }
}
