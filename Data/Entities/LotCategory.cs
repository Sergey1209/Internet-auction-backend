using System.Collections.Generic;

namespace Data.Entities
{
    public class LotCategory : BaseEntity
    {
        public string Name { get; set; }
        public int? FileId { get; set; }

        public virtual IEnumerable<Lot> Lots { get; set; }
        public virtual File File { get; set; }
    }
}
