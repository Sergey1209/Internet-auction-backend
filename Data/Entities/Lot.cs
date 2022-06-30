using System.Collections.Generic;

namespace Data.Entities
{
    public class Lot : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// ID category of the lots
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// ID person of the people. The person who is the owner of this lot.
        /// </summary>
        public int OwnerId { get; set; }

        public virtual LotCategory Category { get; set; }
        public virtual Auction Auction { get; set; }
        public virtual IEnumerable<LotImage> LotImages { get; set; }
    }
}
