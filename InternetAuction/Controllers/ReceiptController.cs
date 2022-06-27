using Business.Interfaces;
using Business.Models;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Exceptions]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        //[Authorize(Roles = "Administrator, RegisteredUser")]
        [HttpPost]
        public async Task Post([FromBody] ReceiptModel model)
        {
            await _receiptService.AddAsync(model);
        }

    }
}
