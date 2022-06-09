using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class LotCategory : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Lot> Lots { get; set; }
    }
}
