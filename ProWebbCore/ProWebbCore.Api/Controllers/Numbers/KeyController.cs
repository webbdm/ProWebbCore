using ProWebbCore.Api.Models;
using ProWebbCore.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProWebbCore.Shared.Numbers;
using System.Collections.Generic;

namespace ProWebbCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyController : Controller
    {
        private readonly KeyRepository _keyRepository;

        public KeyController(KeyRepository keyRepository)
        {
            _keyRepository = keyRepository;
        }

        [HttpGet]
        public List<Key> GetAllKeys()
        {
            return _keyRepository.GetAllKeys();
        }

        [HttpGet]
        [Route("getKeyById/{keyId}")]
        public Key GetKeyById(int keyId)
        {
            return _keyRepository.GetKeyById(keyId);
        }
    }
}
