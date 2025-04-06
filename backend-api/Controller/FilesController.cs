using FileUploaderSample.Domains.Entities;
using FileUploaderSample.Infrastructure.EFConfig;
using FileUploaderSample.Requests;
using FileUploaderSample.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileUploaderSample.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : BaseController
    {
        
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

       
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileRequest request)
        {           
            var response  = await _fileService.SaveFileToDatabase(request.File);
            return getActionResultObject(response.HttpStatusCode, response);
        }

        [HttpGet("lists")]
        public async Task<IActionResult> GetAllFileLists([FromQuery] FileListRequest request)
        {
            var response = await _fileService.GetAllFilesAsync(request);
            return getActionResultObject(response.HttpStatusCode, response);
        }
    }
}
