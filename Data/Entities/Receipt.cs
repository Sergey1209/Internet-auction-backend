using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Receipt : BaseEntity
    {
        public int LotId { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Cost { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }       

        public Lot Lot { get; set; }
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
    }
}
