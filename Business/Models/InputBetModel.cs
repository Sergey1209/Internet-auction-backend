using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    /// <summary>
    /// The model accepting data from the request in the AuctionController. 
    /// </summary>
    public class InputBetModel
    {
        /// <summary>
        /// Auction ID
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Bet amount
        /// </summary>
        [Required]
        public int BetValue { get; set; }
    }
}
