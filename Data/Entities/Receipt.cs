using System;

namespace Data.Entities
{
    public class Receipt : BaseEntity
    {
        public int LotId { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Cost { get; set; }
        public int CustomerId { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
