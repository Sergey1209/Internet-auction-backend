using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Interfaces;
using System.Linq;
using InternetAuction.Extensions;

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController: ControllerBase
    {
        private readonly ILotService _service;
        private readonly ILotImageService _lotImageService;

        public LotController(ILotService service, ILotImageService lotImageService)
        {
            _service = service;
            _lotImageService = lotImageService;
        }

        // GET: api/<Lot>
        [HttpGet]
        public async Task<IEnumerable<LotModel>> GetAll() 
        {
            var res = await _service.GetAllAsync();
            return res;
        }

        // GET: api/category/5
        [HttpGet("category/{id}")]
        public async Task<IEnumerable<LotModel>> GetAllByDetalsByCategoryId(int id)
        {
            var res = await _service.GetAllByCategoryIdAsync(id);
            return res;
        }

        // GET api/<Lot>/5
        [HttpGet("{id}")]
        public async Task<LotModel> Get(int id)
        {
            var res = await _service.GetByIdAsync(id);
            return res;
        }

        // POST api/<Lot>
        [HttpPost]
        public async Task Post([FromForm] InputLotModel inputModel)
        {
            var lotId = await _service.AddAsync(inputModel);
            await _lotImageService.AddAsync(lotId: inputModel.Id, images: inputModel.Files);
        }

        // PUT api/<Lot>/5
        [HttpPut]
        public async Task Put([FromForm] InputLotModel inputModel)
        {
            if (inputModel == null)
                throw new System.ArgumentNullException("inputModel");

            await _lotImageService.DeleteByLotIdAsync(lotId: inputModel.Id);
            await _service.UpdateAsyc(inputModel);
            await _lotImageService.AddAsync(lotId: inputModel.Id, images: inputModel.Files);
        }

        // DELETE api/<Lot>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _lotImageService.DeleteByLotIdAsync(lotId: id);
            await _service.DeleteAsync(id);
        }
    }
}
