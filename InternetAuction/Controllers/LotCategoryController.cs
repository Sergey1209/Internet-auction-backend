using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Interfaces;
using System.Linq;
using InternetAuction.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    public class LotCategoryController : ControllerBase
    {
        private readonly ILotCategoryService _service;
        private readonly IFileService _fileService;

        public LotCategoryController(ILotCategoryService service, IFileService filsService)
        {
            _service = service;
            _fileService = filsService;
        }

        // GET: api/<LotCategory>
        [HttpGet]
        public async Task<IEnumerable<LotCategoryModel>> GetAll()
        {
            var res = await _service.GetAllAsync();
            return res;
        }

        // GET api/<LotCategory>/5
        [HttpGet("{id}")]
        public async Task<LotCategoryModel> Get(int id)
        {
            var res = await _service.GetByIdAsync(id);
            return res;
        }

        // POST api/<LotCategory>
        [HttpPost]
        public async Task Post([FromForm] InputLotCategoryModel inputLotCategory)
        {
            if (inputLotCategory == null)
                throw new System.ArgumentNullException("inputLotCategory");

            var img = inputLotCategory.Files?.First();
            int? fileId = default;
            if (img != null)
                fileId  = await _fileService.AddAsync(img);
            
            await _service.AddAsync(name: inputLotCategory.Name, fileId: fileId);
        }

        // Put api/<LotCategory>
        [HttpPut]
        public async Task Put([FromForm] InputLotCategoryModel inputLotCategory)
        {
            if (inputLotCategory == null)
                throw new System.ArgumentNullException("inputLotCategory");

            var oldFileId = await _service.GetFileId(lotCategoryId: inputLotCategory.Id);
            await _fileService.UpdateAsync(id: oldFileId, newFile: inputLotCategory.Files.First());

            await _service.UpdateAsyc(inputLotCategory);
        }

        // DELETE api/<LotCategory>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
