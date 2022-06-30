using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Processes the buyer's bid. Customer ID ID is taken from the token.
        /// </summary>
        /// <param name="bet">Bet value</param>
        /// <returns></returns>
        [Authorize(Roles = "RegisteredUser")]
        [HttpPost("{id}/bet")]
        public async Task MakeBet([FromBody] InputBetModel bet)
        {
            var customerId = _token.GetPersonId(HttpContext);
            await _auctionService.MakeBetAsync(id: bet.Id, betValue: bet.BetValue, customerId: customerId);
        }

        /// <summary>
        /// Returns auction by id.
        /// </summary>
        /// <param name="id">Auction ID</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, RegisteredUser")]
        [HttpGet("{id}")]
        public async Task<AuctionModel> GetById(int id)
        {
            return await _auctionService.GetByIdAsync(id);
        }

        /// <summary>
        /// Returns the current max bet for this auction ID.
        /// </summary>
        /// <param name="id">Auction ID</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator, RegisteredUser")]
        [HttpGet("{id}/bet")]
        public async Task<AuctionModel> GetBetvalueById(int id)
        {
            return await _auctionService.GetBetValueByIdAsync(id);
        }
    }
}
