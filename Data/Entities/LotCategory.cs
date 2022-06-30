using System.Collections.Generic;

namespace Data.Entities
{
    public class LotCategory : BaseEntity
    {
        /// <summary>
        /// Lot name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// File id (image) of this category 
        /// </summary>
        public int? FileId { get; set; }

        public virtual IEnumerable<Lot> Lots { get; set; }
        public virtual File File { get; set; }
    }
}
