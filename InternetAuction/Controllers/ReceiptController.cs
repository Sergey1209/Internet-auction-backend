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
    [ValidateModelState]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        // GET: api/<ReceiptController>
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IEnumerable<ReceiptModel>> GetAll()
        {
            return await _receiptService.GetAllAsync();
        }

        // GET api/<ReceiptController>/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public async Task<ReceiptModel> Get(int id)
        {
            return await _receiptService.GetByIdAsync(id);
        }

        // POST api/<ReceiptController>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task Post([FromBody] ReceiptModel model)
        {
            await _receiptService.AddAsync(model);
        }

    }
}
