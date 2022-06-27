using Business.Interfaces;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Exceptions]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _service;

        public FilesController(IFileService service)
        {
            _service = service;
        }

        // GET api/<ImagesController>/path
        [HttpGet("{name}")]
        public async Task<FileResult> Get(string name)
        {
            var file = await _service.UploadImageAsync(name);
            var result = File(file.ContentData, file.ContentType);
            return result;
        }
    }
}
