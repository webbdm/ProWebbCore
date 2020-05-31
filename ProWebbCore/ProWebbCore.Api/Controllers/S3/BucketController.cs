using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProWebbCore.Api.Models;
using ProWebbCore.Infrastructure.Communication.Interfaces;
using ProWebbCore.Infrastructure.Communication.Bucket;

namespace ProWebbCore.Api.Controllers.S3
{
    [Route("api/bucket")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IBucketRepository _bucketRepository;

        public BucketController(IBucketRepository bucketRepository)
        {
            _bucketRepository = bucketRepository;
        }


        [HttpPost]
        [Route("create/{bucketName}")]
        public async Task<ActionResult<CreateBucketResponse>> CreateS3Bucket([FromRoute] string bucketName)
        {
            var bucketExists = await _bucketRepository.DoesS3BucketExist(bucketName);

            // TODO: Investigate. This always returns true for some reason
            // if (bucketExists)
            // {
            //    return BadRequest("S3 bucket already exists");
            // }

            var result = await _bucketRepository.CreateBucket(bucketName);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<ListS3BucketResponse>>> ListS3Buckets()
        {
            var result = await _bucketRepository.ListBuckets();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{bucketName}")]
        public async Task<ActionResult> DeleteS3Bucket(string bucketName)
        {
            await _bucketRepository.DeleteBucket(bucketName);

            return Ok();
        }
    }
}
