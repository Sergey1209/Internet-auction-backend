using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Provides tools for handling auction controller data.
    /// </summary>
    public interface IAuctionService
    {
        /// <summary>
        /// Saves the user's bid if it's valid
        /// </summary>
        /// <param name="id">Auction id</param>
        /// <param name="betValue">Bet value</param>
        /// <param name="customerId">The person who made this bet</param>
        /// <returns></returns>
        public Task MakeBetAsync(int id, decimal betValue, int customerId);
        /// <summary>
        /// Returns auction data
        /// </summary>
        /// <param name="id">Auction id</param>
        /// <returns></returns>
        public Task<AuctionModel> GetByIdAsync(int id);
        /// <summary>
        /// Returns the bet value for this auction.
        /// </summary>
        /// <param name="id">Aucton id</param>
        /// <returns></returns>
        public Task<AuctionModel> GetBetValueByIdAsync(int id);
    }
}
