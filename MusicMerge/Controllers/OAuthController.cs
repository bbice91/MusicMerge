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

namespace MusicMerge.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OAuthController : ControllerBase
    {
        private readonly SpotifyService _spotifyService;
        private readonly UserContext _userContext;

        public OAuthController(UserContext userContext, SpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            _userContext = userContext;
        }

        [HttpGet]
        [Route("/authorize/{code}/{authorize}")]
        public async Task<IActionResult> Login([FromRoute] string code, [FromRoute] Authorize authorize)
        {
            var token = authorize switch
            {
                Authorize.Spotify => await _spotifyService.GetToken(code),
            };

            var spotifyUser = await _spotifyService.GetSpotifyUser(token.AccessToken);

            if (spotifyUser == null)
            {
                return Unauthorized();
            }

            await _userContext.UpsertSpotifyUser(spotifyUser, token.AccessToken);

            return Ok(spotifyUser);
        }

        [HttpPost]
        [Route("/api/token")]
<<<<<<< Updated upstream

<<<<<<< Updated upstream
        //public async Task<IActionResult> GetAccess([FromRoute] string accessToken, string grantType)
        //{

        //}
=======

=======


>>>>>>> Stashed changes
        public async Task<IActionResult> GetAccess([FromRoute] string accessToken)
        {
            return Ok(accessToken);
        }

>>>>>>> Stashed changes
    }
}
