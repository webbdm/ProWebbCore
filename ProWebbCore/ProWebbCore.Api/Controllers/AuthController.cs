using ProWebbCore.Api.Models;
using ProWebbCore.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace ProWebbCore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        [Route("callback")]
        [HttpGet]
        public IActionResult callback()
        {
            return Ok("yayyyyyyy");
        }
    }
}