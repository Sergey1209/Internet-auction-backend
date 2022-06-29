using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Exceptions]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;
        private readonly TokenHelper _token;

        public AuctionController(IAuctionService auctionService, TokenHelper token)
        {
            _auctionService = auctionService;
            _token = token;
        }

        [Authorize(Roles = "RegisteredUser")]
        [HttpPost("{id}/bet")]
        public async Task MakeBet([FromBody] InputBetModel bet)
        {
            var customerId = _token.GetPersonId(HttpContext);
            await _auctionService.MakeBetAsync(id: bet.Id, betValue: bet.BetValue, customerId:customerId);
        }

        [Authorize(Roles = "Administrator, RegisteredUser")]
        [HttpGet("{id}")]
        public async Task<AuctionModel> GetById(int id)
        {
            return await _auctionService.GetByIdAsync(id);
        }

        [Authorize(Roles = "Administrator, RegisteredUser")]
        [HttpGet("{id}/bet")]
        public async Task<AuctionModel> GetBetvalueById(int id)
        {
            return await _auctionService.GetBetValueByIdAsync(id);
        }
    }
}
