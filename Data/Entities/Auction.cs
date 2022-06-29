using System;

namespace Data.Entities
{
    public class Auction : BaseEntity
    {
        public int LotId { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal BetValue { get; set; }
        public int CustomerId { get; set; }
        public DateTime? Deadline { get; set; }
        public decimal? InitialPrice { get; set; }


        public virtual Lot Lot { get; set; }
    }
}
