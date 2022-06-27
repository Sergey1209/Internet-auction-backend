using System;

namespace Business.Models
{
    public class ReceiptModel
    {
        public int LotId { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Cost { get; set; }
        public int CustomerId { get; set; }
    }
}
