using System.Collections.Generic;

namespace Data.Entities
{
    public class File : BaseEntity
    {
        /// <summary>
        /// File name with extension
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Category of lots with which this file is associated. Only for category of lots.
        /// </summary>
        public virtual LotCategory LotCategory { get; set; }

        /// <summary>
        /// Related collection of lotimages. For lots only.
        /// </summary>
        public virtual IEnumerable<LotImage> LotImages { get; set; }
    }
}
