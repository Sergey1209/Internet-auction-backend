using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Lot : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal InitialPrice { get; set; }
        public int CategoryId { get; set; }

        public LotCategory Category { get; set; }
        public Receipt Receipt { get; set; }

    }
}
