using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private readonly ILotService _service;
        private readonly TokenHelper _token;
        /// <summary>
        /// Number of lots for each request
        /// </summary>
        private const int numberLotsOfReturn = 10;

        public LotController(ILotService service, TokenHelper token)
        {
            _service = service;
            _token = token;
        }

        [HttpGet]
        public async Task<IEnumerable<LotModel>> GetAll()
        {
            var res = await _service.GetAllAsync();
            return res;
        }

        [HttpGet("{id1}-{id2}")]
        public async Task<IEnumerable<LotModel>> GetAll(int id1, int id2)
        {
            if (id1 == 0 || id2 == 0)
            {
                var min = Math.Min(id1, id2);
                if (min == 0) min = 12;

                var res = await _service.GetLastAsync(min);
                return res;
            }
            {
                var res = await _service.GetRangeAsync(id1, id2);
                return res;
            }
        }

        [HttpGet("{id}")]
        public async Task<LotModel> GetById(int id)
        {
            var res = await _service.GetByIdAsync(id);
            return res;
        }

        /// <summary>
        /// Returns lots from categories
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="lotId">ID below which the selection will be performed</param>
        /// <returns></returns>
        [HttpGet("category/{categoryId}/{lotId}")]
        public async Task<IEnumerable<LotModel>> GetRangeByCategory(int categoryId, int lotId)
        {
            var res = await _service.GetRangeLotsByCategoryIdAsync(
                    categoryId: categoryId, lotId: lotId, numberLots: numberLotsOfReturn);

            return res;
        }

        /// <summary>
        /// Filtering is done in the lot description
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="lotId">ID below which the selection will be performed</param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IEnumerable<LotModel>> GetAllByFilter()
        {
            string searchstring = HttpContext.Request.Headers["searchstring"];

            string lotidStr = HttpContext.Request.Headers["lotid"];
            int lotid = int.Parse(lotidStr);
            int.TryParse(lotidStr, out int id);

            var res = await _service.GetByFilter(searchString: searchstring, lotId: id, numberLots: numberLotsOfReturn);
            return res;
        }

        [Authorize(Roles = "RegisteredUser")]
        [HttpPost]
        public async Task Post([FromForm] InputLotModel inputModel)
        {
            ValidateModel(inputModel);
            inputModel.OwnerId = _token.GetPersonId(HttpContext);
            await _service.AddAsync(inputModel);
        }

        [Authorize(Roles = "RegisteredUser")]
        [HttpPut]
        public async Task Put([FromForm] InputLotModel inputModel)
        {
            ValidateModel(inputModel);

            if (await IsOwnerOfLot(inputModel.Id))
                await _service.UpdateAsyc(inputModel);
            else
                throw new System.Exception("Only the owner can change the lot");
        }

        [Authorize(Roles = "Administrator, RegisteredUser")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            if (await IsOwnerOfLot(id) || IsAdmin())
                await _service.DeleteAsync(id);
            else
                throw new System.Exception("Only the owner and administrator can change the lot");
        }

        private async Task<bool> IsOwnerOfLot(int lotId)
        {
            var lot = await _service.GetByIdAsync(lotId);
            return lot.OwnerId == _token.GetPersonId(HttpContext);
        }
        private bool IsAdmin()
        {
            return _token.GetRole(HttpContext).ToString() == "Administrator";
        }
        private void ValidateModel(InputLotModel model)
        {
            if (model == null)
                throw new NullModelException("inputModel");
        }

    }
}
