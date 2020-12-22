using ProWebbCore.Api.Models;
using ProWebbCore.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProWebbCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        [HttpPost]
        [Route("/auth/callback")]
        public bool Callback()
        {
            return true;
        }
    }
}