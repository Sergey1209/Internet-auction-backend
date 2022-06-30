using Business.Interfaces;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("{name}")]
        public async Task<FileResult> Get(string name)
        {
            var file = await _service.UploadImageAsync(name);
            var result = File(file.ContentData, file.ContentType);
            return result;
        }
    }
}
