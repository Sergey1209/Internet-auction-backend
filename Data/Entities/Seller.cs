using System.Collections.Generic;

namespace Data.Entities
{
    public class Seller : BaseEntity
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }
        public IEnumerable<Receipt> Receipts { get; set; }
    }
}
