using System.Collections.Generic;

namespace Data.Entities
{
    public class File : BaseEntity
    {
        public string Name { get; set; }

        public virtual LotCategory LotCategory { get; set; }
        public virtual IEnumerable<LotImage> LotImages { get; set; }
    }
}
