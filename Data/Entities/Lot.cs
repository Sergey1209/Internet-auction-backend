using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Lot : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? InitialPrice { get; set; }
        public int CategoryId { get; set; }
        public DateTime? Deadline { get; set; }
        public int OwnerId { get; set; }

        public virtual LotCategory Category { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual IEnumerable<LotImage> LotImages { get; set; }
    }
}
