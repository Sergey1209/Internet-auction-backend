using System;

namespace Data.Entities
{
    public class Auction : BaseEntity
    {
        /// <summary>
        /// Auction lot id
        /// </summary>
        public int LotId { get; set; }
        /// <summary>
        /// Date and time of the last bet
        /// </summary>
        public DateTime OperationDate { get; set; }
        /// <summary>
        /// The value of the last bet
        /// </summary>
        public decimal BetValue { get; set; }
        /// <summary>
        /// Customer who made the last bet
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Deadline the auction
        /// </summary>
        public DateTime? Deadline { get; set; }
        /// <summary>
        /// The initial cost of the lot, set by the owner.
        /// </summary>
        public decimal? InitialPrice { get; set; }


        /// <summary>
        /// A navigation property that represents the entity of the lot for this auction
        /// </summary>
        public virtual Lot Lot { get; set; }
    }
}
