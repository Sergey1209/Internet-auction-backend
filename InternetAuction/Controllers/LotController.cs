﻿using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("category/{id}")]
        public async Task<IEnumerable<LotModel>> GetAllByCategoryId(int id)
        {
            var res = await _service.GetAllByCategoryIdAsync(id);
            return res;
        }

        [HttpGet("{id}")]
        public async Task<LotModel> Get(int id)
        {
            var res = await _service.GetByIdAsync(id);
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
