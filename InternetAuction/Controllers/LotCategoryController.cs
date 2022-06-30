using Business.Interfaces;
using Business.Models;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Exceptions]
    public class LotCategoryController : ControllerBase
    {
        private readonly ILotCategoryService _service;

        public LotCategoryController(ILotCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<LotCategoryModel>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public async Task<LotCategoryModel> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task Post([FromForm] InputLotCategoryModel inputLotCategory)
        {
            await _service.AddAsync(inputLotCategory);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task Put([FromForm] InputLotCategoryModel inputLotCategory)
        {
            await _service.UpdateAsyc(inputLotCategory);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
