using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProWebbCore.Api.Models;
using ProWebbCore.Infrastrucutre.Communication.Interfaces;
using ProWebbCore.Infrastructure.Communication.Files;

namespace ProWebbCore.Api.Controllers.S3
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesRepository _filesRepository;

        public FilesController(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        [HttpPost]
        [Route("{bucketName}/add")]
        public async Task<ActionResult<AddFileResponse>> AddFiles(string bucketName, IList<IFormFile> formFiles) // "formFiles" or any key needs to match in the request
        {
            if (formFiles == null)
            {
                return BadRequest("The request doesn't contain any files to be uploaded");
            }

            var response = await _filesRepository.UploadFiles(bucketName, formFiles);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{bucketName}/list")]
        public async Task<ActionResult<IEnumerable<ListFilesResponse>>> ListFiles(string bucketName)
        {
            var responses = await _filesRepository.ListFiles(bucketName);

            if (responses == null)
            {
                return BadRequest();
            }

            return Ok(responses);
        }

        [HttpGet]
        [Route("{bucketName}/download/{fileName}")]
        public async Task<ActionResult> DownloadFile(string bucketName, string fileName)
        {
            await _filesRepository.DownloadFile(bucketName, fileName);

            return Ok();
        }

        [HttpDelete]
        [Route("{bucketName}/delete/{fileName}")]
        public async Task<ActionResult<DeleteFileResponse>> DeleteFile(string bucketName, string fileName)
        {
            var response = await _filesRepository.DeleteFile(bucketName, fileName);

            return Ok(response);
        }

        [HttpPost]
        [Route("{bucketName}/addjsonobject")]
        public async Task<IActionResult> AddJsonObject(string bucketName, AddJsonObjectRequest request)
        {
            await _filesRepository.AddJsonObject(bucketName, request);

            return Ok();
        }

        [HttpGet]
        [Route("{bucketName}/getjsonobject")]
        public async Task<ActionResult<GetJsonObjectResponse>> GetJsonObject(string bucketName, string fileName)
        {
            var response = await _filesRepository.GetJsonObject(bucketName, fileName);

            return Ok(response);
        }
    }
}
