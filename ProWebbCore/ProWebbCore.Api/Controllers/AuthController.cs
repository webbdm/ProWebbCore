using Microsoft.AspNetCore.Mvc;
using ProWebbCore.Shared.Auth;

namespace ProWebbCore.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("/callback")]
        [HttpPost]
        public IActionResult Callback(AccessToken token)
        {
            // Create the access token record in the database

            // Send a response
            // This should then redirect user from auth with valid access token

            return Ok();
        }
    }
}